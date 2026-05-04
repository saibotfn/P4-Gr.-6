using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private float deathLimit = 0;

    void Update()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        if(transform.position.x < deathLimit)
        {
            Destroy(gameObject);
        }
    }
}
