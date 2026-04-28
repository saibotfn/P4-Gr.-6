using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

[RequireComponent(typeof(UIDocument))]
public class SongCarouselController : MonoBehaviour
{
    [Header("Songs")]
    public List<SongData> songs = new();

    private UIDocument _doc;
    private VisualElement _cardStack;
    private int _currentIndex = 0;

    private static readonly string[] Slots =
        { "prev2", "prev1", "active", "next1", "next2" };

    void OnEnable()
    {
        _doc = GetComponent<UIDocument>();
        var root = _doc.rootVisualElement;
        root.Clear();

        // Baggrund
        root.style.backgroundColor = new Color(0.31f, 0f, 0.39f);
        root.style.width = Length.Percent(100);
        root.style.height = Length.Percent(100);
        root.style.alignItems = Align.Center;
        root.style.justifyContent = Justify.Center;

        // Card stack
        _cardStack = new VisualElement();
        _cardStack.style.width = Length.Percent(100);
        _cardStack.style.height = Length.Percent(100);
        _cardStack.style.alignItems = Align.Center;
        _cardStack.style.justifyContent = Justify.Center;
        root.Add(_cardStack);

        // Prev knap
        var btnPrev = new Button(() => Navigate(-1)) { text = "‹" };
        StyleNavButton(btnPrev, false);
        root.Add(btnPrev);

        // Next knap
        var btnNext = new Button(() => Navigate(+1)) { text = "›" };
        StyleNavButton(btnNext, true);
        root.Add(btnNext);

        // Swipe
        float startX = 0;
        root.RegisterCallback<PointerDownEvent>(e => startX = e.position.x);
        root.RegisterCallback<PointerUpEvent>(e =>
        {
            float delta = e.position.x - startX;
            if (Mathf.Abs(delta) > 50)
                Navigate(delta < 0 ? 1 : -1);
        });

        if (songs.Count == 0)
        {
            Debug.LogError("Songs listen er tom — træk SongData assets ind i Inspector!");
            return;
        }

        BuildCards();
    }

    void StyleNavButton(Button btn, bool isRight)
    {
        btn.style.position = Position.Absolute;
        btn.style.bottom = 40;
        btn.style.width = 60;
        btn.style.height = 60;
        btn.style.borderTopLeftRadius = 30;
        btn.style.borderTopRightRadius = 30;
        btn.style.borderBottomLeftRadius = 30;
        btn.style.borderBottomRightRadius = 30;
        btn.style.backgroundColor = new Color(1f, 1f, 1f, 0.2f);
        btn.style.color = Color.white;
        btn.style.fontSize = 24;
        btn.style.unityTextAlign = TextAnchor.MiddleCenter;
        btn.style.borderLeftWidth = 0;
        btn.style.borderRightWidth = 0;
        btn.style.borderTopWidth = 0;
        btn.style.borderBottomWidth = 0;

        if (isRight)
            btn.style.right = 60;
        else
            btn.style.left = 60;
    }

    void BuildCards()
    {
        _cardStack.Clear();

        int[] offsets = { -2, -1, 0, 1, 2 };

        foreach (int offset in offsets)
        {
            int songIndex = WrapIndex(_currentIndex + offset);
            var card = CreateCard(songs[songIndex]);
            StyleCard(card, offset);

            if (offset == 0)
            {
                card.RegisterCallback<PointerEnterEvent>(_ =>
                {
                    card.BringToFront();
                    card.style.scale = new Scale(new Vector3(1.08f, 1.08f, 1f));
                    card.style.translate = new Translate(0f, -28f, 0f);
                });

                card.RegisterCallback<PointerLeaveEvent>(_ =>
                {
                    StyleCard(card, 0);
                    card.BringToFront();
                });

                card.BringToFront();
            }

            _cardStack.Add(card);
        }
    }

    VisualElement CreateCard(SongData song)
    {
        var card = new VisualElement();
        card.AddToClassList("song-card");
        card.style.width = 220;
        card.style.height = 300;
        card.style.borderTopLeftRadius = 20;
        card.style.borderTopRightRadius = 20;
        card.style.borderBottomLeftRadius = 20;
        card.style.borderBottomRightRadius = 20;
        card.style.overflow = Overflow.Hidden;
        card.style.position = Position.Absolute;
        

        // Cover art
        if (song.coverArt != null)
        {
            var cover = new VisualElement();
            cover.style.width = Length.Percent(100);
            cover.style.height = Length.Percent(100);
            cover.style.position = Position.Absolute;
            cover.style.backgroundImage = new StyleBackground(song.coverArt);
            cover.style.unityBackgroundScaleMode = ScaleMode.ScaleAndCrop;
            card.Add(cover);
        }

        // År badge øverst til venstre
        var yearLabel = new Label(song.year);
        yearLabel.style.position = Position.Absolute;
        yearLabel.style.top = 12;
        yearLabel.style.left = 12;
        yearLabel.style.color = Color.white;
        yearLabel.style.fontSize = 16;
        yearLabel.style.unityFontStyleAndWeight = FontStyle.Bold;
        card.Add(yearLabel);

        // Overlay nederst
        var overlay = new VisualElement();
        overlay.style.position = Position.Absolute;
        overlay.style.bottom = 0;
        overlay.style.left = 0;
        overlay.style.right = 0;
        overlay.style.height = 80;
        overlay.style.backgroundColor = new Color(0f, 0f, 0f, 0.6f);
        overlay.style.paddingLeft = 10;
        overlay.style.paddingRight = 10;
        overlay.style.paddingTop = 10;
        overlay.style.justifyContent = Justify.Center;
        card.Add(overlay);

        var author = new Label(song.author);
        author.style.color = Color.white;
        author.style.fontSize = 13;
        author.style.unityFontStyleAndWeight = FontStyle.Bold;
        overlay.Add(author);

        var title = new Label(song.songName);
        title.style.color = new Color(1f, 1f, 1f, 0.8f);
        title.style.fontSize = 11;
        overlay.Add(title);

        return card;
    }

    void StyleCard(VisualElement card, int offset)
    {
        // Farver per position
        Color[] colors = {
            new Color(0.78f, 0.47f, 0.20f), // prev2
            new Color(0.31f, 0.47f, 0.78f), // prev1
            new Color(0f,    0.71f, 0.63f), // active (teal)
            new Color(0.78f, 0.59f, 0.20f), // next1
            new Color(0.39f, 0.31f, 0.78f), // next2
        };

        float[] scales   = { 0.72f, 0.85f, 1.0f,  0.85f, 0.72f };
        float[] translateX = { -340f, -200f, 0f, 200f, 340f };
        float[] translateY = {  40f,   20f, -10f,  20f,  40f };

        int i = offset + 2;
        card.style.backgroundColor = colors[i];
        card.style.scale = new Scale(new Vector3(scales[i], scales[i], 1f));
        card.style.translate = new Translate(translateX[i], translateY[i], 0f);
    }

    int WrapIndex(int idx)
    {
        int n = songs == null ? 0 : songs.Count;
        if (n == 0) return 0;
        idx %= n;
        if (idx < 0) idx += n;
        return idx;
    }

    void Navigate(int direction)
    {
        int newIndex = _currentIndex + direction;
        _currentIndex = WrapIndex(newIndex);
        BuildCards();
    }
}