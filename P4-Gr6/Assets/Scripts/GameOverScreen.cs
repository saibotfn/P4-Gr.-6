using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private UIDocument document;

    private Button retryButton;
    private Button songButton;

    [SerializeField] private string sceneLoadSelect;
    [SerializeField] private string sceneLoadRetry;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        retryButton = document.rootVisualElement.Q("TryAgain") as Button;
        retryButton.RegisterCallback<ClickEvent>(Retry);

        songButton = document.rootVisualElement.Q("TryAgain") as Button;
        songButton.RegisterCallback<ClickEvent>(GoToSongSelect);
    }

    private void OnDisable()
    {
        retryButton.UnregisterCallback<ClickEvent>(Retry);
        songButton.UnregisterCallback<ClickEvent>(GoToSongSelect);
    }

    private void GoToSongSelect(ClickEvent evt)
    {
        Debug.Log("You Pressed The Song Select Button");
        SceneManager.LoadScene(sceneLoadSelect);
    }

    private void Retry(ClickEvent evt)
    {
        Debug.Log("You Pressed Retry Button Button");
        SceneManager.LoadScene(sceneLoadRetry);
    }
}