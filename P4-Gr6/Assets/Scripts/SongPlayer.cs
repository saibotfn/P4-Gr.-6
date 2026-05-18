using UnityEngine;
using System.Collections.Generic;
using Minis;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Linq;


public class SongPlayer : MonoBehaviour
{
    [SerializeField] private ZombieSpawner spawner;
    [SerializeField] private KeyboardRaycast raycaster;
    [SerializeField] private ScoreManager scoreManager;

    private NoteSequence song = new NoteSequence { };
    public static List<Zombie> Instances = new List<Zombie>();

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
            scoreManager = Object.FindFirstObjectByType<ScoreManager>();
    }

    void OnEnable()
    {
        InputSystem.onDeviceChange += OnDeviceChange;

        foreach (var device in InputSystem.devices)
        {
            if (device is MidiDevice midi)
            {
                midi.onWillNoteOn += OnNoteOn;
            }
        }
    }

    void OnDisable()
    {
        InputSystem.onDeviceChange -= OnDeviceChange;

        foreach (var device in InputSystem.devices)
        {
            if (device is MidiDevice midi)
            {
                midi.onWillNoteOn -= OnNoteOn;
            }
        }
    }

    void OnDeviceChange(InputDevice device, InputDeviceChange change)
    {
        if (device is MidiDevice midi)
        {
            if (change == InputDeviceChange.Added ||
                change == InputDeviceChange.Reconnected)
            {
                midi.onWillNoteOn += OnNoteOn;
            }

            if (change == InputDeviceChange.Removed ||
                change == InputDeviceChange.Disconnected)
            {
                midi.onWillNoteOn -= OnNoteOn;
            }
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
            }
        }
    }
    private void LateUpdate()
    {
        Zombie someZombie = Object.FindFirstObjectByType<Zombie>();

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

        bool allNotesSpawned = song.events.All(e => e.time >= 100000);
        if (allNotesSpawned && someZombie == null && timePased > songDuration)
        {
            Win();
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
    public void Win()
    {
        GameSettings.score = scoreManager.score;
        GameSettings.misses = scoreManager.miss;
        if(GameSettings.adaptivePlay == false)
        {
            GameSettings.highScore = Mathf.Max(GameSettings.highScore, scoreManager.score);
        }
        SceneManager.LoadScene("WinScreen");
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

