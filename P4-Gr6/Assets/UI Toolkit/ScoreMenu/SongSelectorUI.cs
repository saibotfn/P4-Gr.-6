using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

public class SongSelectorUI : MonoBehaviour
{
    [SerializeField] private string PlaySceneName = "TestingWithZombies";

    public List<SongData> songs;

    private ListView listView;
    private Label songTitle;
    private Slider speedSlider;
    private Label speedLabel;
    private Button playButton;

    private SongData selectedSong;
    private float selectedSpeed = 1f;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        listView = root.Q<ListView>();
        songTitle = root.Q<Label>("song-title");
        speedSlider = root.Q<Slider>("speedSlider");
        speedLabel = root.Q<Label>("speedLabel");
        playButton = root.Q<Button>("play-button");

        SetupList();
        SetupSpeed();
        SetupPlay();
    }

    void SetupList()
    {
        listView.itemsSource = songs;
        listView.makeItem = () => new Label();
        listView.bindItem = (element, i) =>
        {
            (element as Label).text = songs[i].songName;
        };

        listView.selectionChanged += (selectedItems) =>
        {
            foreach (var item in selectedItems)
            {
                selectedSong = item as SongData;
                songTitle.text = selectedSong.songName;
            }
        };
    }

    void SetupSpeed()
    {
        speedSlider.RegisterValueChangedCallback(evt =>
        {
            selectedSpeed = evt.newValue;
            speedLabel.text = $"Speed: {selectedSpeed:F2}x";
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
