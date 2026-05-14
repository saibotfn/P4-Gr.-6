using UnityEngine;
using System.Collections.Generic;
using Minis;
using UnityEngine.InputSystem;
using System.Linq;


public class SongPlayer : MonoBehaviour
{
    [SerializeField] private ZombieSpawner spawner;
    [SerializeField] private KeyboardRaycast raycaster;
    [SerializeField] private ScoreManager scoreManager;

    private NoteSequence song = new NoteSequence { };
    public static List<Zombie> Instances = new List<Zombie>();
    private bool firstZombieSpawned = false;

    private int highestNote = 108;
    private int lowestNote = 21;

    private float timePased = 0;
    private float songDuration = 1f;

    //[SerializeField] private int songIndex;
    //public TextAsset[] jsonFile;

    //[SerializeField] [Range(0.1f,4f)] private float playSpeed = 1f;
    private float playSpeed = 1f;

    void Start()
    {
        //song = readJsonFile(jsonFile[songIndex]);
        song = readJsonFile(GameSettings.selectedSong.jsonFile);
        Debug.Log($"Selected song: {GameSettings.selectedSong.name}");
        playSpeed = GameSettings.selectedSpeed;

        if (song.events.Count > 0)
            songDuration = song.events.Max(e => e.time);

        if (scoreManager == null)
            scoreManager = FindObjectOfType<ScoreManager>();
    }

    void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;
    }

    void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;
    }
    void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        // Check if the device is a MIDI device
        if (device is MidiDevice midi)
        {
            Debug.Log("Device found");
            // Subscribe to note events
            midi.onWillNoteOn += OnNoteOn;
        }
    }

    void OnNoteOn(MidiNoteControl note, float velocity)
    {
        Debug.Log($"Note pressed: {note.noteNumber}, velocity: {velocity}");
        raycaster.shootRay(note.noteNumber);
    }

    void Update()
    {
        if (scoreManager != null)
            scoreManager.SetSongProgress(timePased / songDuration);
        
        foreach (NoteEvent timing in song.events)
        {
            if(timePased > timing.time)
            {
                timing.time += 100000;
                spawner.SpawnZombie(timing);
                firstZombieSpawned = true;
            }
        }
    }
    private void LateUpdate()
    {
        Zombie someZombie = FindObjectOfType<Zombie>();

        if (someZombie != null)
        {
            if (someZombie.moving)
            {
                timePased += Time.deltaTime * playSpeed;
            }
        }
        else
        {
            timePased += Time.deltaTime * playSpeed;
        }
    }

    private NoteSequence readJsonFile(TextAsset file)
    {
        NoteSequence newSong = new NoteSequence { };

        Notes midiSong = JsonUtility.FromJson<Notes>(file.text);

        foreach(note Note in midiSong.notes)
        {
            newSong.AddEvent(new List<int> { Note.pitch }, Note.startTime, Note.duration, midiSong.metadata.bpm);
        }

        return newSong;
    }
}

[System.Serializable]
public class SongMetadata
{
    public float bpm;
    public float duration;
}

[System.Serializable]
public class Notes
{
    public SongMetadata metadata;
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
