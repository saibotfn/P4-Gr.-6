using UnityEngine;

[CreateAssetMenu(fileName = "TutorialCardData", menuName = "Tutorial/Tutorial Card Data")]
public class TutorialCardData : ScriptableObject
{
    [TextArea(3, 8)]
    public string text;
}
