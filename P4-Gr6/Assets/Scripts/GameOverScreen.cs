using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    private UIDocument document;

    private Button retryButton;
    private Button songButton;
    private Label scoreLabel;
    private Label highScoreLabel;
    private Label missesLabel;

    [SerializeField] private string sceneLoadSelect;
    [SerializeField] private string sceneLoadRetry;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        retryButton = document.rootVisualElement.Q("TryAgain") as Button;
        retryButton.RegisterCallback<ClickEvent>(Retry);

        songButton = document.rootVisualElement.Q("SongSelect") as Button;
        songButton.RegisterCallback<ClickEvent>(GoToSongSelect);

        if (SceneManager.GetActiveScene().name == "WinScreen")
        {
            scoreLabel = document.rootVisualElement.Q("Score") as Label;
            highScoreLabel = document.rootVisualElement.Q("HighScore") as Label;
            missesLabel = document.rootVisualElement.Q("Misses") as Label;
            scoreLabel.text = "Score: " + GameSettings.score.ToString() + " | ";
            highScoreLabel.text = "High Score: " + GameSettings.highScore.ToString();
            missesLabel.text = "Misses: " + GameSettings.misses.ToString() + " | ";
        }
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