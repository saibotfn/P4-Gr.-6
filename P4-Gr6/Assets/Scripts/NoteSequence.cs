using System.Collections.Generic;
using UnityEngine;

public class NoteSequence
{

    public List<NoteEvent> events = new List<NoteEvent>();

    public void AddEvent(List<string> Notes, float Time)
    {
        events.Add(new NoteEvent(Notes, Time));
    }
}
