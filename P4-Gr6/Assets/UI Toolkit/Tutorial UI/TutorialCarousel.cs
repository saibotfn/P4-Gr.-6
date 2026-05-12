using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class TutorialCarousel : MonoBehaviour
{
    public UIDocument document;

    [Header("Cards")]
    public List<TutorialCardData> cards = new List<TutorialCardData>();

    private VisualElement content;
    private Button nextBtn;
    private Button prevBtn;
    private Button continueBtn;

    private int currentIndex = 0;

    void Start()
    {
        if (document == null)
        {
            document = GetComponent<UIDocument>();
        }

        if (document == null)
        {
            Debug.LogError("TutorialCarousel: UIDocument reference mangler.", this);
            return;
        }

        var root = document.rootVisualElement;

        content = root.Q<VisualElement>("carouselContent");
        nextBtn = root.Q<Button>("nextBtn");
        prevBtn = root.Q<Button>("prevBtn");
        continueBtn = root.Q<Button>("continueBtn");

        if (content == null)
        {
            Debug.LogError("TutorialCarousel: Kunne ikke finde 'carouselContent' i UXML.", this);
            return;
        }

        BuildCardsFromScriptableObjects();

        if (nextBtn != null)
            nextBtn.clicked += Next;

        if (prevBtn != null)
            prevBtn.clicked += Previous;

        if (continueBtn != null)
            continueBtn.clicked += Continue;

        UpdateCarousel();
    }

    void BuildCardsFromScriptableObjects()
    {
        if (cards == null || cards.Count == 0)
        {
            return;
        }

        content.Clear();

        for (int i = 0; i < cards.Count; i++)
        {
            var cardData = cards[i];

            var card = new VisualElement();
            card.AddToClassList("card");

            var label = new Label(GetCardText(cardData));
            label.AddToClassList("card-label");

            card.Add(label);
            content.Add(card);
        }

        currentIndex = Mathf.Clamp(currentIndex, 0, Mathf.Max(0, content.childCount - 1));
    }

    string GetCardText(TutorialCardData cardData)
    {
        if (cardData == null)
        {
            return "(Mangler ScriptableObject)";
        }

        return cardData.text;
    }

    void Next()
    {
        int max = content.childCount - 1;
        currentIndex = Mathf.Min(currentIndex + 1, max);
        UpdateCarousel();
    }

    void Previous()
    {
        currentIndex = Mathf.Max(currentIndex - 1, 0);
        UpdateCarousel();
    }

    void Continue()
    {
        var activeScene = SceneManager.GetActiveScene();
        int nextSceneIndex = activeScene.buildIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("TutorialCarousel: Ingen næste scene i Build Settings.");
        }
    }

    void UpdateCarousel()
    {
        if (content.childCount == 0)
        {
            if (nextBtn != null) nextBtn.SetEnabled(false);
            if (prevBtn != null) prevBtn.SetEnabled(false);
            return;
        }

        for (int i = 0; i < content.childCount; i++)
        {
            var card = content[i];
            bool isActive = i == currentIndex;
            card.style.display = isActive ? DisplayStyle.Flex : DisplayStyle.None;
        }

        if (nextBtn != null) nextBtn.SetEnabled(currentIndex < content.childCount - 1);
        if (prevBtn != null) prevBtn.SetEnabled(currentIndex > 0);
        if (continueBtn != null) continueBtn.SetEnabled(content.childCount > 0 && currentIndex == content.childCount - 1);
    }
}

