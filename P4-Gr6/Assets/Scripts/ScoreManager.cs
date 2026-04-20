using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int hits;
    public int miss;
    public int score;

    [SerializeField] private TMP_Text ScoreText;
    [SerializeField] private TMP_Text MissText;

    public void AddHit()
    {  
        hits++;
        ScoreText.text = "Hits =" + ScoreText.ToString();
    }

    public void AddMiss()
    {
        miss--;
        MissText.text = "Misses =" + MissText.ToString();
    }
}