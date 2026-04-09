using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument document;

    private Button button;

    private void Awake()
    {
        document = GetComponent<UIDocument>();

        button = document.rootVisualElement.Q("Start") as Button;
        button.RegisterCallback<ClickEvent>(OnPLayGameClick);
    }

    private void OnDisable()
    {
        button.UnregisterCallback<ClickEvent>(OnPLayGameClick);
    }

    private void OnPLayGameClick(ClickEvent evt)
    {
        Debug.Log("You Pressed The Start Button");
        SceneManager.LoadScene("OliverTesting");
    }
}
