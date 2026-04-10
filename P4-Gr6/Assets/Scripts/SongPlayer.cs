using UnityEngine;
using System.Collections.Generic;
using MidiJack;
using System.IO;


public class SongPlayer : MonoBehaviour
{
    [SerializeField] private ZombieSpawner spawner;
    [SerializeField] private KeyboardRaycast raycaster;

    private NoteSequence song = new NoteSequence { };

    private int highestNote = 108;
    private int lowestNote = 21;

    private float timePased = 0;

    [SerializeField] private int songIndex;
    public TextAsset[] jsonFile;

    void Start()
    {
        song = readJsonFile(jsonFile[songIndex]);
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
                Debug.Log(raycaster.shootRay(i));
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

    private NoteSequence readJsonFile(TextAsset file)
    {
        NoteSequence newSong = new NoteSequence { };

        Notes midiSong = JsonUtility.FromJson<Notes>(file.text);

        foreach(note Note in midiSong.notes)
        {
            newSong.AddEvent(new List<int> { Note.pitch }, Note.startTime);
        }

        return newSong;
    }

   
}

[System.Serializable]
public class Notes
{
    public note[] notes;
}

[System.Serializable]
public class note
{
    public int instrumentId;
    public string instrumentName;
    public bool isPercussion;
    public int pitch;
    public int velocity;
    public float startTime;
    public float duration;
    public float endTime;
}
