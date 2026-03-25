using UnityEngine;

public class NoteEvent
{
    public List<string> Notes { get; set; }  // chord or single note
    public double Time { get; set; }         // seconds or beats

    public NoteEvent(List<string> notes, double time)
    {
        Notes = notes;
        Time = time;
    }
}
