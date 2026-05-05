using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CaruselMenu : MonoBehaviour
{
    private UIDocument document;

    private VisualElement carouselContainer;
    private Button leftArrow;
    private Button rightArrow;

    private List<VisualElement> cards = new List<VisualElement>();

    private int selectedIndex = 0;

    private void Awake()
    {
        document = GetComponent<UIDocument>();

        VisualElement root = document.rootVisualElement;

        carouselContainer = root.Q<VisualElement>("carouselContainer");
        leftArrow = root.Q<Button>("leftArrow");
        rightArrow = root.Q<Button>("rightArrow");

        cards = carouselContainer.Query<VisualElement>(className: "card").ToList();

        leftArrow.clicked += MoveLeft;
        rightArrow.clicked += MoveRight;

        UpdateCards();
    }

    private void MoveLeft()
    {
        selectedIndex--;

        if (selectedIndex < 0)
            selectedIndex = cards.Count - 1;

        UpdateCards();
    }

    private void MoveRight()
    {
        selectedIndex++;

        if (selectedIndex >= cards.Count)
            selectedIndex = 0;

        UpdateCards();
    }

    private void UpdateCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            VisualElement card = cards[i];

            int offset = i - selectedIndex;

            // Makes the carousel wrap around
            if (offset > cards.Count / 2)
                offset -= cards.Count;

            if (offset < -cards.Count / 2)
                offset += cards.Count;

            float xPosition = offset * 220f;

            float scale = offset == 0 ? 1.0f : Mathf.Abs(offset) == 1 ? 0.85f : 0.7f;
            float opacity = Mathf.Abs(offset) > 2 ? 0f : Mathf.Abs(offset) == 2 ? 0.3f : 1f;

            card.style.translate = new Translate(xPosition, 0, 0);
            card.style.scale = new Scale(new Vector3(scale, scale, 1f));
            card.style.opacity = opacity;
            card.pickingMode = PickingMode.Ignore;
        }

        // Put the selected card visually in front
        cards[selectedIndex].BringToFront();
    }
}  

