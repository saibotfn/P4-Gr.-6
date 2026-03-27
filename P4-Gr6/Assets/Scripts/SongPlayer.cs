using UnityEngine;
using System.Collections.Generic;
using MidiJack;


public class SongPlayer : MonoBehaviour
{
    private NoteSequence song = new NoteSequence { };

    private int highestNote = 108;
    private int lowestNote = 21;

    void Start()
    {
        song = CreateSong();

        string nextNotes = "Play: ";
        foreach (NoteEvent note in song.events)
        {
            nextNotes += note.notes[0];
            nextNotes += ", ";
        }
        Debug.Log(nextNotes);
    }

    void Update()
    {
        int playedNote = 0;
        for (int i = lowestNote; i <= highestNote; i++)
        {
            if (MidiMaster.GetKeyDown(i))
            {
                playedNote = i;
            }
        }

        if (playedNote > 0 && song.events.Count > 0)
        {
            if(playedNote == song.events[0].notes[0])
            {
                song.events.RemoveAt(0);
            }
            string nextNotes = "Play: ";
            foreach(NoteEvent note in song.events)
            {
                nextNotes += note.notes[0];
                nextNotes += ", ";
            }
            Debug.Log(nextNotes);
        }
    }

    private NoteSequence CreateSong()
    {
        NoteSequence newSong = new NoteSequence { };

        newSong.AddEvent(new List<int> { 47 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 55 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 47 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 50 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 45 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 55 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 45 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 50 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 47 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 55 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 47 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 50 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 49 }, 0);
        newSong.AddEvent(new List<int> { 52 }, 0);
        newSong.AddEvent(new List<int> { 57 }, 0);
        newSong.AddEvent(new List<int> { 52 }, 0);
        newSong.AddEvent(new List<int> { 49 }, 0);
        newSong.AddEvent(new List<int> { 52,59 }, 0);
        newSong.AddEvent(new List<int> { 45,62 }, 0);
        newSong.AddEvent(new List<int> { 52,64 }, 0);
        newSong.AddEvent(new List<int> { 47,59 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 55 }, 0);
        newSong.AddEvent(new List<int> { 54,66 }, 0);
        newSong.AddEvent(new List<int> { 67 }, 0);
        newSong.AddEvent(new List<int> { 47,69 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 50 }, 0);
        newSong.AddEvent(new List<int> { 54, 67 }, 0);
        newSong.AddEvent(new List<int> { 69 }, 0);
        newSong.AddEvent(new List<int> { 45,71 }, 0);
        newSong.AddEvent(new List<int> { 47 }, 0);
        newSong.AddEvent(new List<int> { 54 }, 0);
        newSong.AddEvent(new List<int> { 69 }, 0);
        newSong.AddEvent(new List<int> { 55 }, 0);
        newSong.AddEvent(new List<int> { 54,67 }, 0);


        return newSong;
    }
}
