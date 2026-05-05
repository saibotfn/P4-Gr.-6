import json
import math
from collections import defaultdict

# ── Load JSON ──────────────────────────────────────────────────────────────
with open(r'c:\Users\tobia\Documents\GitHub\Unity\P4-Gr6\P4-Gr6\Assets\Json\Rush E.json', encoding='utf-8') as f:
    data = json.load(f)

bpm = data['metadata']['bpm']           # ≈ 70
quarter_dur = 60.0 / bpm               # seconds per quarter note
# 64th-note grid: 16 ticks per quarter
TICKS_PER_QUARTER = 16
tick_dur = quarter_dur / TICKS_PER_QUARTER  # seconds per tick

# ── MIDI ➜ LilyPond note name ──────────────────────────────────────────────
_NOTE_NAMES = ['c', 'cis', 'd', 'dis', 'e', 'f', 'fis', 'g', 'gis', 'a', 'ais', 'b']

def midi_to_lily(pitch: int) -> str:
    name = _NOTE_NAMES[pitch % 12]
    # In LilyPond absolute mode: c' = C4 = MIDI 60
    # octave marks relative to MIDI 48 (= "c" with no mark, i.e. C3)
    octave = (pitch // 12) - 4          # 0 → no mark, 1 → ', 2 → '', …
    if octave > 0:
        name += "'" * octave
    elif octave < 0:
        name += "," * abs(octave)
    return name

# ── Tick count ➜ LilyPond duration string(s) ──────────────────────────────
# ticks per rhythmic value (base = 16 ticks per quarter)
_DUR_TABLE = [
    (64, '1'),    # whole
    (48, '1.'),   # dotted whole
    (32, '2'),    # half
    (24, '2.'),   # dotted half
    (16, '4'),    # quarter
    (12, '4.'),   # dotted quarter
    (8,  '8'),    # eighth
    (6,  '8.'),   # dotted eighth
    (4,  '16'),   # sixteenth
    (3,  '16.'),  # dotted sixteenth
    (2,  '32'),   # thirty-second
    (1,  '64'),   # sixty-fourth
]

def ticks_to_lily_durs(ticks: int) -> list[str]:
    """Break tick count into LilyPond duration tokens (tied if needed)."""
    result = []
    remaining = ticks
    while remaining > 0:
        found = False
        for tick_val, dur_str in _DUR_TABLE:
            if remaining >= tick_val:
                result.append(dur_str)
                remaining -= tick_val
                found = True
                break
        if not found:
            break
    return result if result else ['64']

def to_ticks(seconds: float) -> int:
    return max(1, round(seconds / tick_dur))

# ── Group notes by time bucket ─────────────────────────────────────────────
# notes that start within half a 64th note of each other are simultaneous
CHORD_TOLERANCE = tick_dur * 0.5

def group_events(note_list):
    """Return list of (start_tick, [pitches], duration_ticks)."""
    if not note_list:
        return []
    note_list = sorted(note_list, key=lambda n: n['startTime'])
    events = []
    i = 0
    while i < len(note_list):
        ref_time = note_list[i]['startTime']
        chord_notes = []
        j = i
        while j < len(note_list) and abs(note_list[j]['startTime'] - ref_time) <= CHORD_TOLERANCE:
            chord_notes.append(note_list[j])
            j += 1
        start_tick = to_ticks(ref_time)
        # use the longest duration among simultaneous notes
        dur_tick = max(to_ticks(n['duration']) for n in chord_notes)
        pitches = sorted(set(n['pitch'] for n in chord_notes))
        events.append((start_tick, pitches, dur_tick))
        i = j
    return events

# ── Render a voice (list of events) to LilyPond tokens ────────────────────
def render_voice(events) -> list[str]:
    tokens = []
    cursor = 0  # current position in ticks

    for (start_tick, pitches, dur_tick) in events:
        # insert rest if there is a gap
        gap = start_tick - cursor
        if gap > 0:
            rest_durs = ticks_to_lily_durs(gap)
            for i, d in enumerate(rest_durs):
                tokens.append(f'r{d}')
            cursor += gap

        durs = ticks_to_lily_durs(dur_tick)

        if len(pitches) == 1:
            note_lily = midi_to_lily(pitches[0])
            for i, d in enumerate(durs):
                token = f'{note_lily}{d}'
                if i > 0:
                    token = '~ ' + token
                tokens.append(token)
        else:
            # chord: <note1 note2 ...>dur
            chord_notes = ' '.join(midi_to_lily(p) for p in pitches)
            for i, d in enumerate(durs):
                token = f'<{chord_notes}>{d}'
                if i > 0:
                    token = '~ ' + token
                tokens.append(token)

        cursor += dur_tick

    return tokens

# ── Build per-instrument event lists ──────────────────────────────────────
instrument_notes = defaultdict(list)
for n in data['notes']:
    instrument_notes[n['instrumentId']].append(n)

instrument_events = {}
for inst_id, notes in instrument_notes.items():
    instrument_events[inst_id] = group_events(notes)

# ── Assemble LilyPond source ───────────────────────────────────────────────
TICKS_PER_MEASURE = TICKS_PER_QUARTER * 4  # 4/4

def format_tokens(tokens, measure_ticks=TICKS_PER_MEASURE) -> str:
    """Insert bar comments every measure for readability."""
    lines = []
    buf = []
    tick_count = 0

    def dur_str_to_ticks(d: str) -> int:
        base = int(d.rstrip('.'))
        base_ticks = {1: 64, 2: 32, 4: 16, 8: 8, 16: 4, 32: 2, 64: 1}.get(base, 1)
        if d.endswith('.'):
            base_ticks = base_ticks + base_ticks // 2
        return base_ticks

    i = 0
    measure = 1
    beat = 0
    for token in tokens:
        is_tied = token.startswith('~')
        clean = token.lstrip('~ ')
        # extract duration suffix
        if clean.startswith('<'):
            dur_part = clean.split('>')[1]
        elif clean.startswith('r'):
            dur_part = clean[1:]
        else:
            # last digits+dot
            import re
            m = re.search(r'(\d+\.?)$', clean)
            dur_part = m.group(1) if m else '4'

        t = dur_str_to_ticks(dur_part)
        buf.append(token)
        beat += t
        if beat >= measure_ticks:
            lines.append('  ' + ' '.join(buf) + f'  | % m.{measure}')
            buf = []
            measure += 1
            beat -= measure_ticks

    if buf:
        lines.append('  ' + ' '.join(buf))
    return '\n'.join(lines)


right_tokens = render_voice(instrument_events.get(0, []))
left_tokens  = render_voice(instrument_events.get(1, []))

right_body = format_tokens(right_tokens)
left_body  = format_tokens(left_tokens)

tempo_bpm = round(bpm)

lily = rf"""\version "2.24.0"
\header {{
  title = "Rush E"
  composer = "Sheet Music Boss"
  tagline = "Generated from MIDI data"
}}

\score {{
  \new PianoStaff <<
    \new Staff {{
      \clef treble
      \time 4/4
      \tempo 4 = {tempo_bpm}
      \relative {{
{right_body}
      }}
    }}
    \new Staff {{
      \clef bass
      \time 4/4
      \relative {{
{left_body}
      }}
    }}
  >>
  \layout {{ }}
  \midi {{ }}
}}
"""

out_path = r'c:\Users\tobia\Documents\GitHub\Unity\P4-Gr6\P4-Gr6\Assets\Json\Rush E.ly'
with open(out_path, 'w', encoding='utf-8') as f:
    f.write(lily)

print(f"Written: {out_path}")
print(f"Right hand tokens: {len(right_tokens)}")
print(f"Left  hand tokens: {len(left_tokens)}")
