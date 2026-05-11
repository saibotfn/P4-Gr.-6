using UnityEngine;
using OscJack;

public class OSCsender : MonoBehaviour
{
    OscClient client;

    [SerializeField] private ScoreManager scoreManager;

    void Start()
    {
        client = new OscClient("127.0.0.1", 9000);

        InvokeRepeating(nameof(SendAudioData), 0f, 0.05f);
    }

   public void SendAudioData()
    {
        client.Send("/plusStreak", scoreManager.plusHP);
        client.Send("/minusStreak", scoreManager.minusHP);
    }

    void OnDestroy()
    {
        client?.Dispose();
    }
}
