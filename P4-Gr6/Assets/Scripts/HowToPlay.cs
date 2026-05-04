using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class HowToPlay : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "TestingWithZombies";
    [SerializeField] private GameObject blackScreen;
    [SerializeField] private float delayBeforeLoad = 0.15f;

    private bool hasClicked = false;

    void Update()
    {
        if (hasClicked) return;

        bool keyboardPressed = Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame;

        bool mouseClicked = Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame;

        bool screenTouched = Touchscreen.current != null &&
                             Touchscreen.current.primaryTouch.press.wasPressedThisFrame;

        if (keyboardPressed || mouseClicked || screenTouched)
        {
            hasClicked = true;
            StartCoroutine(FadeAndLoad());
        }
    }

    private IEnumerator FadeAndLoad()
    {
        if (blackScreen != null)
        {
            blackScreen.SetActive(true);
        }

        yield return new WaitForSeconds(delayBeforeLoad);

        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}
