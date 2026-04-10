using UnityEngine;
using System.Collections.Generic;
using MidiJack;


public class SongPlayer : MonoBehaviour
{
    [SerializeField] private ZombieSpawner spawner;

    private NoteSequence song = new NoteSequence { };

    private int highestNote = 108;
    private int lowestNote = 21;

    private float timePased = 0;

    void Start()
    {
        song = CreateSong();


    }

    void Update()
    {
        timePased += Time.deltaTime;
        int playedNote = 0;
        for (int i = lowestNote; i <= highestNote; i++)
        {
            if (MidiMaster.GetKeyDown(i))
            {
                playedNote = i;
            }
        }
        
        foreach (NoteEvent timing in song.events)
        {
            if(timePased > timing.time)
            {
                timing.time += 10000;
                spawner.SpawnZombie(timing.notes);
            }
        }


    }

    private NoteSequence CreateSong()
    {
        NoteSequence newSong = new NoteSequence { };

        newSong.AddEvent(new List<int> { 60 }, 1);
        newSong.AddEvent(new List<int> { 60 }, 2);
        newSong.AddEvent(new List<int> { 60 }, 3);
        newSong.AddEvent(new List<int> { 62 }, 4);
        newSong.AddEvent(new List<int> { 64 }, 5);
        newSong.AddEvent(new List<int> { 64 }, 6);
        newSong.AddEvent(new List<int> { 64 }, 7);


        return newSong;
    }
}
