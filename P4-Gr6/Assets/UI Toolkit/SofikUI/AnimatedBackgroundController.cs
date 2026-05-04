using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

[RequireComponent(typeof(UIDocument))]
public class AnimatedBackgroundController : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private List<Texture2D> backgroundFrames = new();
    [SerializeField] private float frameDuration = 0.1f;

    private VisualElement _root;
    private float _frameTimer = 0f;
    private int _currentFrame = 0;

    void OnEnable()
    {
        var doc = GetComponent<UIDocument>();
        _root = doc.rootVisualElement;

        if (backgroundFrames == null || backgroundFrames.Count == 0)
        {
            Debug.LogWarning("Ingen background frames tilføjet! Tilføj teksturer i inspectoren.");
            return;
        }

        // Sæt første frame
        UpdateBackground();
    }

    void Update()
    {
        if (backgroundFrames == null || backgroundFrames.Count == 0)
            return;

        _frameTimer += Time.deltaTime;

        if (_frameTimer >= frameDuration)
        {
            _frameTimer = 0f;
            _currentFrame = (_currentFrame + 1) % backgroundFrames.Count;
            UpdateBackground();
        }
    }

    void UpdateBackground()
    {
        if (_root == null || backgroundFrames == null || backgroundFrames.Count == 0)
            return;

        var texture = backgroundFrames[_currentFrame];
        var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        _root.style.backgroundImage = new StyleBackground(sprite);
    }
}
