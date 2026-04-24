using UnityEngine;

[CreateAssetMenu(fileName = "SongData", menuName = "Add Song")]
public class SongData : ScriptableObject
{
    public string songName;
    public AudioClip audioClip;
    public TextAsset jsonFile;
    public float playSpeed = 1f;

    [Header("UI")]
    public Sprite coverArt;
    public string artistName;
    [TextArea(3, 6)] public string description;

}
