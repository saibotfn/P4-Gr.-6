using UnityEngine;
using System.Collections.Generic;

public class NoteEvent
{
    public List<int> notes;
    public float time;

    public NoteEvent(List<int> Notes, float Time)
    {
        notes = Notes;
        time = Time;
    }
}
