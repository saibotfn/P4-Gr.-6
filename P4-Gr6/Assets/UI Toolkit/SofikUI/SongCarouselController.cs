using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

[RequireComponent(typeof(UIDocument))]
public class SongCarouselController : MonoBehaviour
{
    [Header("Songs")]
    public List<SongData> songs = new();

    [Header("Scene")]
    [SerializeField] private string playSceneName = "TestingWithZombies";

    private UIDocument _doc;
    private VisualElement _cardStack;
    private Label _descriptionLabel;
    private Button _playButton;
    private Slider _speedSlider;
    private float _selectedSpeed = 1f;
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

        // Beskrivelseslabel under kortene
        // _descriptionLabel = new Label(); 
        // _descriptionLabel.style.position = Position.Absolute; 
        // _descriptionLabel.style.left = Length.Percent(50);
        // _descriptionLabel.style.top = 5; // Placeret under kortene
        // _descriptionLabel.style.width = 700; // Bred nok til at rumme længere beskrivelser
        // _descriptionLabel.style.marginLeft = -350; // Centrer labelen
        // _descriptionLabel.style.paddingLeft = 14;
        // _descriptionLabel.style.paddingRight = 14;
        // _descriptionLabel.style.paddingTop = 10;
        // _descriptionLabel.style.paddingBottom = 10;
        // _descriptionLabel.style.backgroundColor = new Color(0f, 0f, 0f, 0.35f);
        // _descriptionLabel.style.color = Color.white;
        // _descriptionLabel.style.fontSize = 25;
        // _descriptionLabel.style.unityTextAlign = TextAnchor.MiddleCenter;
        // _descriptionLabel.style.whiteSpace = WhiteSpace.Normal;
        // _descriptionLabel.style.borderTopLeftRadius = 12;
        // _descriptionLabel.style.borderTopRightRadius = 12;
        // _descriptionLabel.style.borderBottomLeftRadius = 12;
        // _descriptionLabel.style.borderBottomRightRadius = 12;
        // root.Add(_descriptionLabel);

        // Prev knap
        var btnPrev = new Button(() => Navigate(-1)) { text = "‹" };
        StyleNavButton(btnPrev, false);
        root.Add(btnPrev);

        // Next knap
        var btnNext = new Button(() => Navigate(+1)) { text = "›" };
        StyleNavButton(btnNext, true);
        root.Add(btnNext);

        // Start knap under den aktive sang
        _playButton = new Button(PlaySelectedSong) { text = "Start spil" };
        StylePlayButton(_playButton);
        root.Add(_playButton);

        // Hastigheds-slider
        SetupSpeed(root);

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
            // _descriptionLabel.text = "Ingen sang valgt";
            _playButton.SetEnabled(false);
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

    void StylePlayButton(Button btn)
    {
        btn.style.position = Position.Absolute;
        btn.style.left = Length.Percent(50);
        btn.style.bottom = 18;
        btn.style.width = 220;
        btn.style.height = 52;
        btn.style.marginLeft = -110;
        btn.style.borderTopLeftRadius = 26;
        btn.style.borderTopRightRadius = 26;
        btn.style.borderBottomLeftRadius = 26;
        btn.style.borderBottomRightRadius = 26;
        btn.style.backgroundColor = new Color(0f, 0f, 0f, 0.35f);
        btn.style.color = Color.white;
        btn.style.fontSize = 18;
        btn.style.unityFontStyleAndWeight = FontStyle.Bold;
        btn.style.unityTextAlign = TextAnchor.MiddleCenter;
        btn.style.borderLeftWidth = 0;
        btn.style.borderRightWidth = 0;
        btn.style.borderTopWidth = 0;
        btn.style.borderBottomWidth = 0;
        btn.style.backgroundColor = new Color(0.14f, 0.72f, 0.38f, 0.95f);
    }

    void SetupSpeed(VisualElement root)
    {
        _speedSlider = new Slider("Speed", 0.5f, 2f);
        _speedSlider.value = _selectedSpeed;
        _speedSlider.style.position = Position.Absolute;
        _speedSlider.style.left = Length.Percent(50);
        _speedSlider.style.bottom = 78;
        _speedSlider.style.width = 260;
        _speedSlider.style.marginLeft = -130;
        _speedSlider.style.color = Color.white;
        _speedSlider.RegisterValueChangedCallback(evt =>
        {
            _selectedSpeed = evt.newValue;
            _speedSlider.label = $"Speed: {_selectedSpeed:F2}x";
            GameSettings.selectedSpeed = _selectedSpeed;
        });
        _speedSlider.label = $"Speed: {_selectedSpeed:F2}x";
        root.Add(_speedSlider);
        GameSettings.selectedSpeed = _selectedSpeed;
    }

    void BuildCards()
    {
        _cardStack.Clear();

        int[] offsets = { -2, -1, 0, 1, 2 };
        VisualElement activeCard = null;

        foreach (int offset in offsets)
        {
            int songIndex = WrapIndex(_currentIndex + offset);
            var card = CreateCard(songs[songIndex]);
            StyleCard(card, offset);
            card.userData = offset;
            PrepareCardEntrance(card, offset);

            if (offset == 0)
            {
                ApplyActiveCardVisual(card);
                activeCard = card;
                continue;
            }

            _cardStack.Add(card);
        }

        if (activeCard != null)
        {
            _cardStack.Add(activeCard);
        }

        AnimateCardsIn();
        BounceActiveCard(activeCard);
        UpdateDescriptionLabel();
    }

    void PrepareCardEntrance(VisualElement card, int offset)
    {
        float entranceOffset = offset == 0 ? 28f : 42f;
        float[] translateX = { -340f, -200f, 0f, 200f, 340f };
        float[] translateY = { 40f, 20f, -10f, 20f, 40f };
        int i = offset + 2;

        card.style.opacity = 0f;
        card.style.translate = new Translate(translateX[i], translateY[i] + entranceOffset, 0f);
    }

    void AnimateCardsIn()
    {
        if (_cardStack == null)
        {
            return;
        }

        _cardStack.schedule.Execute(() =>
        {
            foreach (var child in _cardStack.Children())
            {
                if (!child.ClassListContains("song-card"))
                {
                    continue;
                }

                int offset = child.userData is int storedOffset ? storedOffset : 0;
                StyleCard(child, offset);

                if (offset == 0)
                {
                    ApplyActiveCardVisual(child);
                }

                child.style.opacity = 1f;
            }
        });
    }

    void BounceActiveCard(VisualElement card)
    {
        if (card == null)
        {
            return;
        }

        card.schedule.Execute(() =>
        {
            ApplyActiveCardVisual(card);
            card.style.scale = new Scale(new Vector3(1.24f, 1.24f, 1f));
            card.style.translate = new Translate(0f, -58f, 0f);
        }).StartingIn(10);

        card.schedule.Execute(() =>
        {
            ApplyActiveCardVisual(card);
        }).StartingIn(170);
    }

    void UpdateDescriptionLabel()
    {
        if (_descriptionLabel == null || songs == null || songs.Count == 0)
        {
            return;
        }

        var activeSong = songs[_currentIndex];
        // _descriptionLabel.text = string.IsNullOrWhiteSpace(activeSong.description)
        //     ? activeSong.songName
        //     : activeSong.description;
    }

    void ApplyActiveCardVisual(VisualElement card)
    {
        card.BringToFront();
        card.style.scale = new Scale(new Vector3(1.16f, 1.16f, 1f));
        card.style.translate = new Translate(0f, -46f, 0f);
        card.style.borderLeftWidth = 6;
        card.style.borderRightWidth = 6;
        card.style.borderTopWidth = 6;
        card.style.borderBottomWidth = 6;
        card.style.borderLeftColor = new Color(0.95f, 0.85f, 0.2f, 1f);
        card.style.borderRightColor = new Color(0.95f, 0.85f, 0.2f, 1f);
        card.style.borderTopColor = new Color(0.95f, 0.85f, 0.2f, 1f);
        card.style.borderBottomColor = new Color(0.95f, 0.85f, 0.2f, 1f);
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

        if (offset == 0)
        {
            card.style.borderLeftWidth = 4;
            card.style.borderRightWidth = 4;
            card.style.borderTopWidth = 4;
            card.style.borderBottomWidth = 4;
            card.style.borderLeftColor = new Color(0.95f, 0.85f, 0.2f, 1f);
            card.style.borderRightColor = new Color(0.95f, 0.85f, 0.2f, 1f);
            card.style.borderTopColor = new Color(0.95f, 0.85f, 0.2f, 1f);
            card.style.borderBottomColor = new Color(0.95f, 0.85f, 0.2f, 1f);
        }
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

    void PlaySelectedSong()
    {
        if (songs == null || songs.Count == 0)
        {
            Debug.LogWarning("Kan ikke starte spillet, fordi der ikke er nogen sange valgt.");
            return;
        }

        var selectedSong = songs[_currentIndex];
        GameSettings.selectedSong = selectedSong;
        GameSettings.selectedSpeed = _selectedSpeed;
        SceneManager.LoadScene(playSceneName);
    }

    
}