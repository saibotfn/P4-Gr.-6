using UnityEngine;
using OscJack;

public class OSCsender : MonoBehaviour
{
    OscClient client;

    [SerializeField] private ScoreManager scoreManager;

    [Range(0, 100)]
    public int health = 100;

    [Range(0f, 1f)]
    public float combatIntensity = 1f;

    void Start()
    {
        client = new OscClient("127.0.0.1", 9000);

        //InvokeRepeating(nameof(SendAudioData), 0f, 0.05f);
    }

   public void SendAudioDataHit()
    {

        client.Send("/hitstreak", scoreManager.plusHP);
        Debug.Log("Hit send");
    }

    public void SendAudioDataMiss()
    {
        client.Send("/minusstreak", scoreManager.minusHP);
        Debug.Log("Miss send");
    }

    void OnDestroy()
    {
        client?.Dispose();
    }
}
