using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private float deathLimit = 0;
    [SerializeField] private float lineLocation = 0;

    [SerializeField] private bool addaptivePlay = true;
    public bool moving;

    public static List<Zombie> Instances = new List<Zombie>();

    void OnEnable()
    {
        Instances.Add(this);
    }

    void OnDisable()
    {
        Instances.Remove(this);
    }

    void Update()
    {
        if (transform.position.x < lineLocation && addaptivePlay)
        {
            foreach (Zombie zombie in Instances)
            {
                zombie.moving = false;
            }
        }

        if (transform.position.x < deathLimit)
        {
            Destroy(gameObject);
        }
    }

    private void LateUpdate()
    {
        if (moving)
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
        moving = true;
    }
}
