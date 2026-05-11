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

        InvokeRepeating(nameof(SendAudioData), 0f, 0.05f);
    }

   public void SendAudioData()
    {
        // client.Send("/plusStreak", scoreManager.plusHP);
        // client.Send("/minusStreak", scoreManager.minusHP);

        client.Send("/health", health);
        Debug.Log("Health send");

        client.Send("/intensity", combatIntensity);
        Debug.Log("intensity send");
    }

    void OnDestroy()
    {
        client?.Dispose();
    }
}
