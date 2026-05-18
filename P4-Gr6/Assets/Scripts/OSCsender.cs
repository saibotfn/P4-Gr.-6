using UnityEngine;
using OscJack;

public class OSCsender : MonoBehaviour
{
    OscClient client;

    [SerializeField] private ScoreManager scoreManager;

    void Start()
    {
        client = new OscClient("127.0.0.1", 9000);

        //InvokeRepeating(nameof(SendAudioData), 0f, 0.05f);
    }

   public void SendAudioDataHit()
    {

        client.Send("/hitstreak", 1);
        Debug.Log("Hit send");
    }

    public void SendAudioDataMiss()
    {
        client.Send("/minusstreak", 0);
        Debug.Log("Miss send");
    }

    void OnDestroy()
    {
        client?.Dispose();
    }
}
