\version "2.24.0"
\header {
  title = "Rush E"
  composer = "Sheet Music Boss"
  tagline = "Generated from MIDI data"
}

\score {
  \new PianoStaff <<
    \new Staff {
      \clef treble
      \time 4/4
      \tempo 4 = 70
      \relative {
  r64 e'8 r2 r4.  | % m.1
  r16. e'16 ~ e'64 r2 r64 e'16 r2.  | % m.2
  r16. e'16 r2.  | % m.3
  r64 e'16 r8 r16. e'16. r8 r16.  | % m.4
  e'16. r8 r32 e'16. r8 r64 e'16. r16. e'16. r16. e'16. r32  | % m.5
  e'16. r16. e'64 r32 e'64 r64 e'64 r32 e'64 r64 e'64 r32 e'64 r64 e'64 r32 <e' e''>64 r64 <e' e''>32 r64 <e'' e'''>32 <e'' e'''>32 r64 <e'' e'''>32 <e''' e''''>32 <e''' e''''>32 r64 <e''' e''''>32 <e''' e''''>32 r1  | % m.6
  r1  | % m.7
  r4  | % m.8
  r8. e'16 ~ e'64 r16 e'16 ~ e'64 r16 e'16 ~ e'64 r16 e'16 r16 r64 e'16 r16 r64 e'16  | % m.9
  r16 r64 e'16 r16 r64 e'16 r16 e'16 r16 r64 e'16 r16 e'16 r16 r64 e'16 r16 e'16 r16  | % m.10
  e'16 r16 e'16 r16 e'16 r16 e'16 r16 e'16 r16 e'16 r16. e'16 r16 e'8  | % m.11
  f'8 e'8. ~ e'64 dis'8. ~ dis'64 e'16 r8 r32 a'16 r8 r16.  | % m.12
  c''2. ~ c''32 r64 d''16. r16  | % m.13
  d''16. r16 d''16. r16. d''16. r16 d''16. r16. c''16. r16 b'16. r16.  | % m.14
  d''16. r16 c''16. r16. c''16. r16. c''16. r16 c''16. r16. c''16.  | % m.15
  r16. b'16. r16. a'16. r16. c''16. r16. b'16. r16. b'16. r16.  | % m.16
  b'16. r16. b'16. r32 fis'16. r8 r64 b'16. r8 gis'16 r4  | % m.17
  r16. e4 ~ e16 r64 e'32 r16. e'32 r16 e'32 r16. e'32 r16.  | % m.18
  e'32 r16. e'32 r16. e'32 r16 e'32 r16. e'32 r16. e'32 r16. e'32 r16. e'32 r16.  | % m.19
  e'32 r32 e'32 r16. e'32 r16. e'32 r16. e'16 ~ e'64 f'16 ~ f'64 e'16 ~ e'64 dis'16 ~ dis'64 e'16 ~ e'64 r16. a'16 ~ a'64  | % m.20
  c''16 ~ c''64 e''16. r8. a''8 ~ a''64 c'''4 ~ c'''64 d'''16 r64 c'''16 b''16 d'''16  | % m.21
  r64 c'''16 b''16 a''16 c'''16 b''16 r64 a''16 gis''16 b''16 a''16 e''16 c''16 a'16 f''16 e''16 d''16  | % m.22
  c''16 b'16 a'16 gis'16 b'16 a'4. ~ a'16. r4.  | % m.23
  r16. e'32 r32 e'32 r64 e'32 r32 e'32 r32 e'32 r64 e'32 r32 e'32 r32 e'32 r64 e'32 r32 e'32 r64 e'32 r32 e'32 r64 e'32 r32 e'32  | % m.24
  r64 e'32 r32 e'32 r64 e'32 r32 e'32 r64 e'32 r32 e'32 r64 e'16. f'16. r64 e'16. dis'16. e'32 r16 r64 a'32 r16 r64 c''4.  | % m.25
  r64 d''32 r64 d''32 r64 d''32 r64 d''32 r64 d''32 r64 c''32 r32 b'32 r64 d''32 r64 c''32 r64 c''32 r64 c''32 r64 c''32 r64 c''32 r64 b'32  | % m.26
  r64 a'32 r64 c''32 r64 b'64 r32 b'64 r32 b'64 r32 b'64 r32 fis'64 r16 r64 b'64 r16 r64 gis'32 r8 r32 e8 ~ e16. e'64 r32 e'64 r32  | % m.27
  e'64 r32 e'64 r32 e'64 r64 e'64 r32 e'64 r32 e'64 r16 r64 e'64 r64 e'64 r32 e'64 r32 e'64 r32 e'64 r64 e'64 r32 e'64 r32 e'16. f'16. e'16. dis'16. e'16.  | % m.28
  r64 a'32 c''32 r64 e''64 r16 a''64 r16 c'''8 ~ c'''32 r64 d'''16. c'''16. b''16. d'''16. c'''16. b''32  | % m.29
  a''32 c'''32 b''32 a''32 gis''32 b''32 r64 a''32 e''32 c''32 r64 a'32 f''32 r64 e''32 d''32 r64 c''32 b'32 a'32 r64 gis'32 b'32 a'8 ~ a'64 r8 r32 d''8.  | % m.30
  ~ d''64 cis''32 d''32 r16. e''32 r32 f''16 r64 e''16 d''16 r64 f''16 e''8. ~ e''64 d''32 c''32 r32 d''32 r16.  | % m.31
  e''4. r64 c''32 r32 b'8. ais'32 b'32 r32 c''32 r16. d''32 r32 c''32  | % m.32
  r32 b'32 r32 d''32 r32 c''16. r64 a'16. r64 c''16. r64 e''16. r64 a''16. r64 e''32 r32 c''32 r32 a'32 r32 d''8.  | % m.33
  cis''32 d''32 r64 e''32 r32 f''32 r32 e''32 r32 d''32 r64 f''32 r32 e''8. d''32 c''32 r64 d''32 r32 e''16. r16 a''8  | % m.34
  ~ a''32 r64 d''16. r16 f''32 r32 e''32 r64 c''32 r32 d''32 r64 b'32 r32 a'16. r8. r64 <e' gis' b' e''>32 r32 <a' c'' e'' a''>32 r8  | % m.35
  r16. e'64 r64 e'64 r64 e'64 e'64 r64 e'64 r64 e'64 e'64 r64 e'64 r64 e'64 r64 e'64 e'64 r64 e'64 r64 e'64 e'64 r64 e'64 r64 e'64 e'64 r64 e'64 r64 e'64 e'64 r64 e'32 f'32 e'32 dis'32 e'64 r64 a'64 r16. c''8.  | % m.36
  r64 d''64 d''64 r64 d''64 r64 d''64 d''64 r64 c''64 r64 b'64 d''64 r64 c''64 r64 c''64 r64 c''64 c''64 r64 c''64 r64 b'64 a'64 r64 c''64 r64 b'64 b'64 r64 b'64 r64 b'64 fis'64 r16. b'64 r32 gis'64 r8.  | % m.37
  e8. r64 e'64 r64 e'64 e'64 r64 e'64 r64 e'64 e'64 r64 e'64 r64 e'64 r32 e'64 r64 e'64 r64 e'64 e'64 r64 e'64 r64 e'64 e'64 r64 e'32 f'32 e'32 dis'32 e'32 a'32 c''32 e''64 r32 a''64 r32 c'''8.  | % m.38
  r64 d'''32 c'''32 b''32 d'''32 c'''32 b''32 a''32 c'''32 b''32 a''32 gis''32 b''32 a''32 e''32 c''32 a'32 f''32 e''32 d''32 c''32 b'32 a'32 gis'32 b'32 a'8.  | % m.39
  <d' e' g' a' b' d'' e'' f'' g'' a'' b'' c''' d''' e''' f''' g''' a''' b''' c'''' d'''' e'''' f'''' g'''' a'''' b'''' c'''''>16. r1  | % m.40
  r1  | % m.41
  r1  | % m.42
  r1  | % m.43
  r1  | % m.44
  r1  | % m.45
  r8 e'64 e'64 r16. e'64 r64 e'64 e'64 r64 e''64 r64 e''64 r64 e'''64 e'''64 r64 e''64 r64 e''64 r64 e'64 e'64 r16. e'64 r64 e'64 e'64 r16.  | % m.46
  e'64 r64 e'32 f'32 r64 dis'32 e'64 r32 a'64 r16. c''8. ~ c''64 d''64 d''64 r64 d''64 r64 d''64 r64 d''64 c''64 r64 b'64 r64 d''64 r64 c''64 c''64 r64 c''64 r64 c''64 r64 c''64 b'64 r64 a'64 r64 c''64 r64 b'64 b'64 r64 b'64  | % m.47
  r64 b'64 r64 fis'64 r32 b'64 r16. gis'64 r8. e8. ~ e64 e'64 e'64 r16. e'64 r64 e'64 e'64 r16. e'64 r32 e'64 r16.  | % m.48
  e'64 r64 e'64 e'64 r16. e'64 r64 e'32 f'32 r64 dis'32 e'32 r64 a'32 c''32 e''64 r32 a''64 r16. c'''8. ~ c'''64 <e'' b'' d'''>32 c'''32 b''32 d'''32 <e'' a'' c'''>32 b''32  | % m.49
  a''32 c'''32 <gis'' b''>32 a''32 gis''32 b''32 <e'' a''>32 e''32 c''32 a'32 f''32 e''32 d''32 c''32 b'32 a'32 gis'32 b'32 a'8. ~ a'64 r64 d''16 ~ d''64 cis''32 d''32 r64 e''32 r32  | % m.50
  f''16. e''16. r64 d''16. f''16. r64 e''16 ~ e''64 d''32 c''32 r64 d''32 r32 e''8 ~ e''32 c''32 r32 b'16 ~ b'64 ais'32 b'32 r64  | % m.51
  c''32 r32 d''32 r64 c''32 r32 b'32 r64 d''32 r32 c''32 r64 a'32 r32 c''32 r64 e''32 r32 a''32 r64 e''32 r32 c''32 r64 a'32 r32 d''16 ~ d''64 cis''32 d''32 r64 e''32 r32 f''32 r64 e''32  | % m.52
  r32 d''32 r64 f''32 r32 e''16 ~ e''64 d''32 c''32 r64 d''32 r32 e''16. r16 a''8 ~ a''32 d''16. r16 f''32 r32 e''32 r64 c''32 r32  | % m.53
  d''32 r64 b'32 r32 a'16. r8. r64 <e' gis' b' e''>32 r32 <a' c'' e'' a''>32 r4. e'64 e'64 r16.  | % m.54
  e'64 r64 e'64 e'64 r64 e''64 r64 e''64 r64 e'''64 e'''64 r64 e''64 r64 e''64 r64 e'64 e'64 r16. e'64 r64 e'64 e'64 r16. e'64 r64 e'32 f'32 r64 dis'32 e'64 r32 a'64 r16. c''8.  | % m.55
  ~ c''64 d''64 d''64 r64 d''64 r64 d''64 r64 d''64 c''64 r64 b'64 r64 d''64 r64 c''64 c''64 r64 c''64 r64 c''64 r64 c''64 b'64 r64 a'64 r64 c''64 r64 b'64 b'64 r64 b'64 r64 b'64 r64 fis'64 r32 b'64 r16. gis'64 r8. e8.  | % m.56
  ~ e64 e'64 e'64 r16. e'64 r64 e'64 e'64 r16. e'64 r32 e'64 r16. e'64 r64 e'64 e'64 r16. e'64 r64 e'32 f'32 r64 dis'32 e'32 r64 a'32 c''32  | % m.57
  e''64 r32 a''64 r16. c'''8. ~ c'''64 <e'' b'' d'''>32 c'''32 b''32 d'''32 <e'' a'' c'''>32 b''32 a''32 c'''32 <gis'' b''>32 a''32 gis''32 b''32 <e'' a''>32 e''32 c''32 a'32 f''32 e''32 d''32 c''32 b'32  | % m.58
  a'32 gis'32 b'32 a'8. ~ a'64 r64 f'64 f'64 r16. f'64 r64 f'64 f'64 r16. f'64 r64 f'64 f'64 r16. f'64 r64 f'64 f'64 r16. f'64 r64 f'64 f'64 r16.  | % m.59
  f'64 r64 f'32 fis'32 r64 e'32 f'64 r32 ais'64 r16. cis''8. ~ cis''64 dis''64 dis''64 r64 dis''64 r64 dis''64 r64 dis''64 cis''64 r64 c''64 r64 dis''64 r64 cis''64 cis''64 r64 cis''64 r64 cis''64 r64 cis''64 c''64 r64 ais'64 r64 cis''64  | % m.60
  r64 c''64 c''64 r64 c''64 r64 c''64 r64 g'64 r32 c''64 r16. a'64 r8. f8. ~ f64 f'64 f'64 r16. f'64 r64 f'64 f'64 r16. f'64 r32  | % m.61
  f'64 r16. f'64 r64 f'64 f'64 r16. f'64 r64 f'32 fis'32 r64 e'32 f'32 r64 ais'32 cis''32 f''64 r32 ais''64 r16. cis'''8. ~ cis'''64 dis'''32 cis'''32 c'''32 dis'''32  | % m.62
  cis'''32 c'''32 ais''32 cis'''32 c'''32 ais''32 a''32 c'''32 ais''32 f''32 cis''32 ais'32 fis''32 f''32 dis''32 cis''32 c''32 ais'32 a'32 c''32 ais'8. ~ ais'64 r64 dis'''32 cis'''32 c'''32 dis'''32 cis'''32  | % m.63
  c'''32 ais''32 cis'''32 c'''32 ais''32 a''32 c'''32 ais''32 f''32 cis''32 ais'32 fis''32 f''32 dis''32 cis''32 c''32 ais'32 a'32 c''32 ais'8. ~ ais'64 <cis'' f'' ais''>32
      }
    }
    \new Staff {
      \clef bass
      \time 4/4
      \relative {
  r1  | % m.1
  r1  | % m.2
  r1  | % m.3
  r1.  | % m.4
  r8 r16. e32 r64 <e, e>32 <e, e>32 r64 <e, e>32 <e,, e,>32 <e,, e,>32 r64 <e,, e,>32 <e,, e,>32  | % m.5
  <a,, a,>8. r4. r64 <c e>8. r4.  | % m.6
  r64 e,8. r4. <c e>8. r4.  | % m.7
  r64 <a,, a,>8. r4. r64 <c e>8.  | % m.8
  r4. e,8. r4.  | % m.9
  r64 <c e>8. r4. r64 a,4 ~ a,16. <c e>16  | % m.10
  ~ <c e>64 r4. e,16 r4. r32 <c e>16 r4.  | % m.11
  r64 a,16 r4. r64 <c e>16 r4.  | % m.12
  r64 e,16 r4. <c e>16 r4.  | % m.13
  a,16 r4. <c e>16 r8 r16. e,16 r8  | % m.14
  r16. <c e>16 r8 r16. a,16 r8 r32 <c e>16 r8 r16. e,16. r8  | % m.15
  r16. <c e>16. r8 r32 gis,16. r8 r16. <d e>16. r8 r32  | % m.16
  e,16. r8 r32 <d e>16. r8 r32 a,16. r8 r64 <c e>16. r8 r32  | % m.17
  e,16. r8 r64 <c e>16. r8 r64 b,16. r8 r64 <dis b>16. r8 fis,16.  | % m.18
  r8 r64 <dis a>16. r8 e16 r4 r16. <e,, e,>4  | % m.19
  ~ <e,, e,>16. fis,64 g,64 gis,64 <a,, a,>16. r8. r64 <c e>16. r8. r64 e,16. r8.  | % m.20
  r64 <c e>16. r8 <a,, a,>16. r8. r64 <c e>16. r8. r64 e,16. r8.  | % m.21
  <c e>16. r8. r64 a,16. r8. <c e>16. r8.  | % m.22
  r64 e,16. r8. <c e>16. r8. a,16. r8. r64 <c e>16. r8.  | % m.23
  e,16. r16 r64 <c e>16. r8. d32 r8. r64 <f b>32 r8.  | % m.24
  r64 c32 r8. <e c'>32 r8. b,32 r8. r64 <d gis>32 r8. a,32  | % m.25
  r8. <c a>32 r8. <e, e>16 r16 <fis, fis>16 r16 <gis, gis>16 r16 <e, e>16 r16 <a, a>4.  | % m.26
  ~ <a, a>16. <e,, e,>4. ~ <e,, e,>64 r64 <fis, g,>64 <gis, a,>8.  | % m.27
  ~ <gis, a,>64 <c e>32 r8. e,32 r16 r64 <c e>32 r16 r64 a,32 r16 r64 <c e>32 r16 r64 e,32 r16 r64 <c e>32 r16 r64 a,32 r16 r64  | % m.28
  <c e>32 r16 r64 e,32 r16 r64 <c e>32 r16 a,32 r16 r64 <c e>32 r16 r64 e,32 r16 <c e>32 r16 r64 gis,32 r16 <d e>32 r16 e,32 r16  | % m.29
  r64 <d e>32 r16 a,32 r16 <c e>32 r16 e,32 r16 <c e>32 r16 b,64 r16 r64 <dis b>64 r16 r64 fis,64 r16 r64 <dis a>64 r16 r64 e32 r8  | % m.30
  r32 <e,, e,>8 ~ <e,, e,>32 <fis, g,>64 <a,, gis, a,>8. <c e>64 r16 r64 e,64 r16 <c e>64 r16 r64 a,16 ~ a,64 <c e>64 r16 r64 e,64 r16 <c e>64 r16  | % m.31
  r64 a,16 ~ a,64 <c e>64 r16 e,64 r16 r64 <c e>64 r16 a,16 ~ a,64 <c e>64 r16 e,64 r16 <c e>64 r16 r64 d64 r16 <f b>64 r16 c64 r16 <e c'>64 r16  | % m.32
  b,64 r16 <d gis>64 r16 a,64 r16. <c a>64 r16 <e, e>32 r16. <fis, fis>32 r16. <gis, gis>32 r16. <e, e>32 r32 <a, a>8 ~ <a, a>64 r64 <a,, a,>8  | % m.33
  <b, c>64 <d, cis d>16 ~ <d, cis d>64 <f a>64 r16. a,16 ~ a,64 <f a>64 r16. d16 r64 <f a>64 r16. a,16 r64 <f a>64 r16. c16 r64 <e a>64 r16.  | % m.34
  a,64 r16. <e a>64 r16 c16 <e a>64 r16. a,64 r16 <e a>64 r16. b,16 <d gis>64 r16. e,64 r16. <d gis>64 r16 b,16 <d gis>64  | % m.35
  r16. e,64 r16. <d gis>64 r16. <c, c>16. r64 <a,, a,>16. r64 <c, c>16. r64 <e, e>16. r64 <a, a>16. r16 r64 <a,, a,>8.  | % m.36
  ~ <a,, a,>64 <b, c cis>64 <d, d>16 <f a>64 r32 a,16 <f a>64 r16. d16 <f a>64 r16. a,16 <f a>64 r32 c16 <e a>64 r16. a,64 r32 <e a>64 r16.  | % m.37
  c16 <e a>64 r32 a,64 r16. <e a>64 r16. b,16 <f a>64 r32 d64 r32 <f a>64 r16. <e, gis, e>32 r64 <c, c>32 r32 <d, d>32 r64 <b,, b,>32 r32 <a,, a,>32 r8  | % m.38
  <e, e>32 r32 <a, e a>32 r8 r16. a,16. r64 <c e>64 r32 e,64 r32 <c e>64 r16. a,64 r32 <c e>64 r16. e,64 r32 <c e>64 r32 a,64 r16. <c e>64  | % m.39
  r32 e,64 r16. <c e>64 r32 a,64 r32 <c e>64 r16. e,64 r32 <c e>64 r16. gis,64 r32 <d e>64 r32 e,64 r16. <d e>64 r32 a,64 r16. <c e>64 r32 e,64 r32 <c e>64 r16.  | % m.40
  b,64 r32 <dis b>64 r32 fis,64 r16. <dis a>64 r32 e64 r8. <e,, e,>8. <fis, g, gis,>64 <a,, a,>16. <c e>64 r16. e,64 r32 <c e>64 r32  | % m.41
  a,16. r64 <c e>64 r32 e,64 r16. <c e>64 r32 a,16. <c e>64 r16. e,64 r32 <c e>64 r16. a,16. <c e>64 r32 e,64 r16. <c e>64 r32 d64  | % m.42
  r16. <f b>64 r32 c64 r32 <e c'>64 r16. b,64 r32 <d gis>64 r16. a,64 r32 <c a>64 r32 <e, e>32 r32 <fis, fis>32 r64 <gis, gis>32 r64 <e, e>32 r32 <a, a>8. r64 <cis,, dis,, f,, fis,, gis,, ais,, c, cis, dis, f, fis, gis, ais, c cis dis f fis gis ais c' cis' dis' f' fis' gis' ais' c''>16.  | % m.43
  r16. a,4 ~ a,16. <c e>16 ~ <c e>64 r4. r32 e,16  | % m.44
  ~ e,64 r4. r64 <c e>16 ~ <c e>64 r4. r32 a,16  | % m.45
  ~ a,64 r4. r64 <c e>16 r4. r64 e,16 r8  | % m.46
  r16. <c e>16 r8 r32 a,16. r8 r32 <c e>16. r8 r32 e,16. r8  | % m.47
  <c e>16. r8 a,16. r8. r64 <c e>32 r8 e,32 r8. r64 <c e>32  | % m.48
  r8. r64 a,8 r64 <c e a>32 r8. e,32 r16 r64 <c e a>32 r8. a,32 r16  | % m.49
  r64 <c e a>32 r16 r64 e,32 r16 <c e a>32 r16 r64 a,32 r16 <c e c'>64 r16 r64 e,64 r16 r64 <c e c'>64 r16 a,64 r16 r64 <c e c'>64 r16 e,64 r16 <c e c'>64 r16  | % m.50
  a,16 ~ a,64 <a c' e'>64 r16 e,64 r16 <a c' e'>64 r16. a,64 r16 <a c' e'>64 r16. e,64 r16. <a c' e'>64 r16. a,64 r16. <c' e' a'>64 r16. e,64  | % m.51
  r16. <c' e' a'>64 r16. a,64 r16. <c' e' c''>64 r32 e,64 r16. <c' e' c''>64 r16. <a,, a,>16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. a,16.  | % m.52
  <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. a,16. <a c' e'>64 r16. e,64 r32 <a c' e'>32 r32 a,16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. gis,64 r32  | % m.53
  <d e gis>64 r16. e,64 r32 <d e gis>64 r16. a,64 r32 <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. b,64 r32 <dis b>64 r16. fis,64 r32 <dis a>64 r16. e64 r8.  | % m.54
  <e,, e,>8. <fis, g, gis,>64 <a,, a,>16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. a,16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16.  | % m.55
  a,16. <a c' e'>32 r32 e,64 r32 <a c' e'>64 r16. a,16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. d64 r32 <f b>64 r16. c64 r32 <e c'>64 r16.  | % m.56
  b,64 r32 <d gis>64 r16. a,64 r32 <c a>64 r16. <e, e>32 r64 <fis, fis>32 r32 <gis, gis>32 r64 <e, e>32 r32 <a, a>8. ~ <a, a>64 r8. r64 <d, d>16.  | % m.57
  <f a>64 r16. a,16. <f a>64 r16. d16. <f a>64 r16. a,16. <f a>64 r16. c16. <e a>64 r16. a,64 r32  | % m.58
  <e a>64 r16. c16. <e a>64 r16. a,64 r32 <e a>64 r16. b,16. <d gis>64 r16. e,64 r32 <d gis>64 r16. b,16. <d gis>64 r16.  | % m.59
  e,64 r32 <d gis>64 r16. <c, c>32 r64 <a,, a,>32 r32 <c, c>32 r64 <e, e>32 r32 <a, a>32 r16 r64 <a,, a,>8. <b, c cis>64 <d, d>16. <f a>64 r16. a,16.  | % m.60
  <f a>64 r16. d16. <f a>64 r16. a,16. <f a>64 r16. c16. <e a>64 r16. a,64 r32 <e a>64 r16. c16.  | % m.61
  <e a>64 r16. a,64 r32 <e a>64 r16. b,16. <f a>64 r16. d64 r32 <f a>64 r16. <e, gis, e>32 r64 <c, c>32 r32 <d, d>32 r64 <b,, b,>32 r32 <a,, a,>32 r8  | % m.62
  <e, e>32 r32 <a, e a>32 r4. <a,, a,>16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. a,16. <a c' e'>64 r16.  | % m.63
  e,64 r32 <a c' e'>64 r16. a,16. <a c' e'>64 r16. e,64 r32 <a c' e'>32 r32 a,16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. gis,64 r32 <d e gis>64 r16.  | % m.64
  e,64 r32 <d e gis>64 r16. a,64 r32 <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. b,64 r32 <dis b>64 r16. fis,64 r32 <dis a>64 r16. e64 r8.  | % m.65
  <e,, e,>8. <fis, g, gis,>64 <a,, a,>16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. a,16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. a,16.  | % m.66
  <a c' e'>32 r32 e,64 r32 <a c' e'>64 r16. a,16. <a c' e'>64 r16. e,64 r32 <a c' e'>64 r16. d64 r32 <f b>64 r16. c64 r32 <e c'>64 r16. b,64 r32 <d gis>64 r16.  | % m.67
  a,64 r32 <c a>64 r16. <e, e>32 r64 <fis, fis>32 r32 <gis, gis>32 r64 <e, e>32 r32 <a, a>8. ~ <a, a>64 r8. r64 <ais,, ais,>16. <ais cis' f'>64 r16.  | % m.68
  f,64 r32 <ais cis' f'>64 r16. ais,16. <ais cis' f'>64 r16. f,64 r32 <ais cis' f'>64 r16. ais,16. <ais cis' f'>64 r16. f,64 r32 <ais cis' f'>32 r32 ais,16. <ais cis' f'>64 r16.  | % m.69
  f,64 r32 <ais cis' f'>64 r16. a,64 r32 <dis f a>64 r16. f,64 r32 <dis f a>64 r16. ais,64 r32 <ais cis' f'>64 r16. f,64 r32 <ais cis' f'>64 r16. c64 r32 <e c'>64 r16.  | % m.70
  g,64 r32 <e ais>64 r16. f64 r8. <f,, f,>8. <g, gis, a,>64 <ais,, ais,>16. <ais cis' f'>64 r16. f,64 r32 <ais cis' f'>64 r16. ais,16.  | % m.71
  <ais cis' f'>64 r16. f,64 r32 <ais cis' f'>64 r16. ais,16. <ais cis' f'>32 r32 f,64 r32 <ais cis' f'>64 r16. ais,16. <ais cis' f'>64 r16. f,64 r32 <ais cis' f'>64 r16. dis64 r32  | % m.72
  <fis c'>64 r16. cis64 r32 <f cis'>64 r16. c64 r32 <dis gis>64 r16. ais,64 r32 <cis ais>64 r16. <f, f>32 r64 <g, g>32 r32 <a, a>32 r64 <f, f>32 r32 <ais, ais>8.  | % m.73
  ~ <ais, ais>64 r8. r64 <dis' fis' c''>32 r16 r64 <cis' f' ais'>32 r16 r64 <c' dis' a'>32 r16 r64 <ais cis' ais'>32 r16 r64 <f, f>32 r64 <g, g>32 r32 <a, a>32 r64 <f, f>32 r32 <ais, ais>8.  | % m.74
  ~ <ais, ais>64 <ais,, ais,>32
      }
    }
  >>
  \layout { }
  \midi { }
}
