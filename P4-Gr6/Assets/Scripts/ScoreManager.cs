using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int hits = 0;
    public int miss = 0;
    public int score;

    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text MissText;

    private void Start()
    {
        ScoreText.text = "Hits = ";
        MissText.text = "Misses = ";
    }

    public void AddHit()
    {  
        hits++;
        ScoreText.text = "Hits = " + hits.ToString();
    }

    public void AddMiss()
    {
        miss++;
        MissText.text = "Misses = " + miss.ToString();
    }
}