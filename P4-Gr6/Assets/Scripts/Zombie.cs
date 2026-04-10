using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 1;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
    }
}
