using System.Collections.Generic;
using UnityEngine;

public class NoteSequence
{

    public List<NoteEvent> events = new List<NoteEvent>();

    public void AddEvent(List<int> Notes, float Time, float Duration, float Bpm)
    {
        events.Add(new NoteEvent(Notes, Time, Duration, Bpm));
    }
}
