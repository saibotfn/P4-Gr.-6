using UnityEngine;
using System.Collections.Generic;

public class NoteEvent
{
    public List<int> notes;
    public float time;
    public float duration;
    public float bpm;

    public NoteEvent(List<int> Notes, float Time, float Duration, float Bpm)
    {
        notes = Notes;
        time = Time;
        duration = Duration;
        bpm = Bpm;
    }
}
