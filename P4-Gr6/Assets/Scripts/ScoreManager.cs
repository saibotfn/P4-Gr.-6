using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int hits = 0;
    public int miss = 0;
    public int score = 0;
    public int hp = 50;
    public int maxHP = 50;
    public int minHP = 0;
    public int minusHP = 1;
    public int plusHP = 1;

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

    public void RemoveHP()
    {
        plusHP = 1;
        if (hp >= minHP)
        {
            hp = hp - minusHP;
        }
        minusHP++;
    }

    public void AddHP()
    {
        minusHP = 1;
        if(hp <= maxHP)
          {
            hp = hp + plusHP;
          }
        plusHP++;
    }
}