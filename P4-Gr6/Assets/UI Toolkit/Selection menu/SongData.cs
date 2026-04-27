using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "Add Song")]
public class SongData : ScriptableObject
{
    public AudioClip audioClip;
    public TextAsset jsonFile;
    public float playSpeed = 1f;

    [Header("UI")]
    public string songName;
    public Sprite coverArt;
    public string author;
    public string year;
    [TextArea(3, 6)] public string description;

}
