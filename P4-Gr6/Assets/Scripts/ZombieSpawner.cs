using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints = new GameObject[0];
    [SerializeField] private GameObject zombiePrefab_White;
    [SerializeField] private GameObject zombiePrefab_Black;
    [SerializeField] private GameObject zombiePrefab;

    [SerializeField] private Vector3 zombieOffset;
    [SerializeField] private TMPro.TMP_FontAsset notationFont;
    private Quaternion zombieRotation;

    private int treble;
    private int bass;

    private void Start()
    {
        zombieRotation = Quaternion.Euler(0, -90, 0);
    }

    public void SpawnZombie(NoteEvent noteEvent)
    {
        GameObject noteObj = null;
        foreach (int i in noteEvent.notes)
        {
            switch (i)
            {
                case 21: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[0].transform.position, zombieRotation);
                    break;
                case 22: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[0].transform.position, zombieRotation);
                    break;
                case 23: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[1].transform.position, zombieRotation);
                    break;
                case 24: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[2].transform.position, zombieRotation);
                    break;
                case 25: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[2].transform.position, zombieRotation);
                    break;
                case 26: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[3].transform.position, zombieRotation);
                    break;
                case 27: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[3].transform.position, zombieRotation);
                    break;
                case 28: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[4].transform.position, zombieRotation);
                    break;
                case 29: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[5].transform.position, zombieRotation);
                    break;
                case 30: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[5].transform.position, zombieRotation);
                    break;
                case 31: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[6].transform.position, zombieRotation);
                    break;
                case 32: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[6].transform.position, zombieRotation);
                    break;
                case 33: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[7].transform.position, zombieRotation);
                    break;
                case 34: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[7].transform.position, zombieRotation);
                    break;
                case 35: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[8].transform.position, zombieRotation);
                    break;
                case 36: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[9].transform.position, zombieRotation);
                    break;
                case 37: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[9].transform.position, zombieRotation);
                    break;
                case 38: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[10].transform.position, zombieRotation);
                    break;
                case 39: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[10].transform.position, zombieRotation);
                    break;
                case 40: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[11].transform.position, zombieRotation);
                    break;
                case 41: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[12].transform.position, zombieRotation);
                    break;
                case 42: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[12].transform.position, zombieRotation);
                    break;
                case 43: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[13].transform.position, zombieRotation);
                    break;
                case 44: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[13].transform.position, zombieRotation);
                    break;
                case 45: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[14].transform.position, zombieRotation);
                    break;
                case 46: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[14].transform.position, zombieRotation);
                    break;
                case 47: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[15].transform.position, zombieRotation);
                    break;
                case 48: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[16].transform.position, zombieRotation);
                    break;
                case 49: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[16].transform.position, zombieRotation);
                    break;
                case 50: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[17].transform.position, zombieRotation);
                    break;
                case 51: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[17].transform.position, zombieRotation);
                    break;
                case 52: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[18].transform.position, zombieRotation);
                    break;
                case 53: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[19].transform.position, zombieRotation);
                    break;
                case 54: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[19].transform.position, zombieRotation);
                    break;
                case 55: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[20].transform.position, zombieRotation);
                    break;
                case 56: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[20].transform.position, zombieRotation);
                    break;
                case 57: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[21].transform.position, zombieRotation);
                    break;
                case 58: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[21].transform.position, zombieRotation);
                    break;
                case 59: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[22].transform.position, zombieRotation);
                    break;
                case 60: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[23].transform.position, zombieRotation);
                    break;
                case 61: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[23].transform.position, zombieRotation);
                    break;
                case 62: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[24].transform.position, zombieRotation);
                    break;
                case 63: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[24].transform.position, zombieRotation);
                    break;
                case 64: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[25].transform.position, zombieRotation);
                    break;
                case 65: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[26].transform.position, zombieRotation);
                    break;
                case 66: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[26].transform.position, zombieRotation);
                    break;
                case 67: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[27].transform.position, zombieRotation);
                    break;
                case 68: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[27].transform.position, zombieRotation);
                    break;
                case 69: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[28].transform.position, zombieRotation);
                    break;
                case 70: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[28].transform.position, zombieRotation);
                    break;
                case 71: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[29].transform.position, zombieRotation);
                    break;
                case 72: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[30].transform.position, zombieRotation);
                    break;
                case 73: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[30].transform.position, zombieRotation);
                    break;
                case 74: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[31].transform.position, zombieRotation);
                    break;
                case 75: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[31].transform.position, zombieRotation);
                    break;
                case 76: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[32].transform.position, zombieRotation);
                    break;
                case 77: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[33].transform.position, zombieRotation);
                    break;
                case 78: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[33].transform.position, zombieRotation);
                    break;
                case 79: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[34].transform.position, zombieRotation);
                    break;
                case 80: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[34].transform.position, zombieRotation);
                    break;
                case 81: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[35].transform.position, zombieRotation);
                    break;
                case 82: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[35].transform.position, zombieRotation);
                    break;
                case 83: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[36].transform.position, zombieRotation);
                    break;
                case 84: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[37].transform.position, zombieRotation);
                    break;
                case 85: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[37].transform.position, zombieRotation);
                    break;
                case 86: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[38].transform.position, zombieRotation);
                    break;
                case 87: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[38].transform.position, zombieRotation);
                    break;
                case 88: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[39].transform.position, zombieRotation);
                    break;
                case 89: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[40].transform.position, zombieRotation);
                    break;
                case 90: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[40].transform.position, zombieRotation);
                    break;
                case 91: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[41].transform.position, zombieRotation);
                    break;
                case 92: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[41].transform.position, zombieRotation);
                    break;
                case 93: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[42].transform.position, zombieRotation);
                    break;
                case 94: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[42].transform.position, zombieRotation);
                    break;
                case 95: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[43].transform.position, zombieRotation);
                    break;
                case 96: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[44].transform.position, zombieRotation);
                    break;
                case 97: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[44].transform.position, zombieRotation);
                    break;
                case 98: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[45].transform.position, zombieRotation);
                    break;
                case 99: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[45].transform.position, zombieRotation);
                    break;
                case 100: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[46].transform.position, zombieRotation);
                    break;
                case 101: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[47].transform.position, zombieRotation);
                    break;
                case 102: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[47].transform.position, zombieRotation);
                    break;
                case 103: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[48].transform.position, zombieRotation);
                    break;
                case 104: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[48].transform.position, zombieRotation);
                    break;
                case 105: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[49].transform.position, zombieRotation);
                    break;
                case 106: //Black
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[49].transform.position, zombieRotation);
                    break;
                case 107: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[50].transform.position, zombieRotation);
                    break;
                case 108: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[51].transform.position, zombieRotation);
                    break;
            }
            GameObject zombieObj = Instantiate(zombiePrefab, noteObj.transform);
            zombieObj.transform.rotation = zombieRotation;
            zombieObj.transform.position = noteObj.transform.position + zombieOffset;

            AttachNotation(noteObj, i, noteEvent.duration, noteEvent.bpm);

            noteObj.GetComponent<Zombie>().zombieAnimator = zombieObj.GetComponent<Animator>();
        }
    }

    private void AttachNotation(GameObject noteObj, int pitch, float duration, float bpm)
    {
        float beatsPerSecond = bpm / 60f;
        float durationInBeats = duration * beatsPerSecond;
        
        string noteType;
        switch (durationInBeats)
        {
            case >= 3.0f:  noteType = "Whole"; break;
            case >= 1.5f:  noteType = "Half"; break;
            case >= 0.75f: noteType = "Quarter"; break;
            case >= 0.375f: noteType = "Eighth"; break;
            default: noteType = "Sixteenth"; break;
        }

        string[] noteNames = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B" };
        int octave = (pitch / 12) - 1;
        string noteName = noteNames[pitch % 12];

        GameObject labelObj = new GameObject("NoteLabel");
        labelObj.transform.SetParent(noteObj.transform);
        labelObj.transform.localPosition = new Vector3(0f, 0.3f, 0f);
        TMPro.TextMeshPro tmp = labelObj.AddComponent<TMPro.TextMeshPro>();
        if (notationFont != null) tmp.font = notationFont;

        // Bravura unicode glyphs
        string noteSymbol;
        switch (noteType)
        {
            case "Whole":     noteSymbol = "\uE1D2"; break; // open notehead, no stem
            case "Half":      noteSymbol = "\uE1D3"; break; // open notehead with stem
            case "Quarter":   noteSymbol = "\uE1D5"; break; // filled notehead with stem
            case "Eighth":    noteSymbol = "\uE1D7"; break; // filled notehead, stem + 1 flag
            default:          noteSymbol = "\uE1D9"; break; // filled notehead, stem + 2 flags (16th)
        }

        string accidental = (pitch % 12 is 1 or 3 or 6 or 8 or 10) ? "\u266F" : ""; // ♯

        tmp.text = $"{accidental}{noteSymbol}";
        tmp.fontSize = 29f;
        tmp.color = Color.black;
        tmp.outlineWidth = 0.05f;
        tmp.outlineColor = Color.white;
        tmp.alignment = TMPro.TextAlignmentOptions.Center;
        labelObj.transform.localRotation = Quaternion.Euler(90f, 90f, 0f);
    }
}
