using UnityEngine;
using System.Collections.Generic;

public class NoteEvent
{
    public List<string> notes;
    public float time;

    public NoteEvent(List<string> Notes, float Time)
    {
        notes = Notes;
        time = Time;
    }
}
