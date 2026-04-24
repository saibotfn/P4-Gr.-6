using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int hits = 0;
    public int miss = 0;
    public int score = 0;

    [SerializeField] private TMP_Text HitsText;
    [SerializeField] private TMP_Text MissText;
    [SerializeField] private TMP_Text ScoreText;


    private void Start()
    {
        HitsText.text = "Hits = ";
        MissText.text = "Misses = ";
        ScoreText.text = "Score = ";

    }

    public void AddHit()
    {  
        hits++;
        HitsText.text = "Hits = " + hits.ToString();
    }

    public void AddMiss()
    {
        miss++;
        MissText.text = "Misses = " + miss.ToString();
    }

    public void AddScore(int value)
    {
        score += value;
        ScoreText.text = "Score = " + miss.ToString();
    }
}