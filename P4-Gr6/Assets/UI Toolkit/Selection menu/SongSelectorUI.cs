using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using Unity.VisualScripting;

public class SongSelectorUI : MonoBehaviour
{
    [SerializeField] private string PlaySceneName = "TestingWithZombies";
    [SerializeField] private VisualTreeAsset songItemTemplate;

    public List<SongData> songs;

    private ListView listView;
    private Label songTitle;
    private Slider speedSlider;
    private Button playButton;
    private Label descriptionText;
    private Image iconImage;

    private SongData selectedSong;
    private float selectedSpeed = 1f;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        listView = root.Q<ListView>();
        songTitle = root.Q<Label>("song-title");
        speedSlider = root.Q<Slider>("speedSlider");
        playButton = root.Q<Button>("play-button");
        descriptionText = root.Q<Label>("description");
        iconImage = root.Q<Image>("iconImage");

        SetupList();
        SetupSpeed();
        SetupPlay();
    }

    void SetupList()
    {
        listView.fixedItemHeight = 128;
        listView.itemsSource = songs;
        listView.makeItem = () => songItemTemplate.CloneTree();
        listView.bindItem = (element, i) =>
        {
            var song = songs[i];
            element.Q<Image>("cover").image = song.coverArt != null ? song.coverArt.texture : null;
            element.Q<Label>("title").text = song.songName;
            element.Q<Label>("author").text = song.author;
            element.Q<Label>("year").text = song.year;
        };

        listView.selectionChanged += (selectedItems) =>
        {
            foreach (var item in selectedItems)
            {
                selectedSong = item as SongData;
                songTitle.text = selectedSong.songName;
                descriptionText.text = selectedSong.description;
                
            }
        };
    }

    void SetupSpeed()
    {
        speedSlider.RegisterValueChangedCallback(evt =>
        {
            selectedSpeed = evt.newValue;
            speedSlider.label = $"Speed: {selectedSpeed:F2}x";
        });
    }

    void SetupPlay()
    {
        playButton.clicked += () =>
        {
            if (selectedSong != null)
            {
                GameSettings.selectedSong = selectedSong;
                GameSettings.selectedSpeed = selectedSpeed;
                UnityEngine.SceneManagement.SceneManager.LoadScene(PlaySceneName);
            }
            else
            {
                Debug.Log("No song selected!");
            }
        };
    }

}
