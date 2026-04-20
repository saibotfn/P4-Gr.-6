using UnityEngine;

[CreateAssetMenu(fileName = "Test", menuName = "Scriptable Objects/Test")]
public class Test : ScriptableObject
{
    public int hits;
    public int miss;
    public int score;
}

public class CreateInstance : MonoBehaviour
{

}