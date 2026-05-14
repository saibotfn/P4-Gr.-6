using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 5;
    [SerializeField] private float deathLimit = 0;
    [SerializeField] private float lineLocation = 0;

    [SerializeField] private bool addaptivePlay = true;
    public bool moving;
    private bool alive = true;

    [SerializeField] private float deathAnimationTime = .5f;
    private float timeSinceDeath = 0f;

    public static List<Zombie> Instances = new List<Zombie>();

    public Animator zombieAnimator;

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
        if (alive)
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
                Attack();
            }
            return;
        }

        timeSinceDeath += Time.deltaTime;
        if(timeSinceDeath >= deathAnimationTime)
        {
            Destroy(gameObject);
        }


    }

    public void Die()
    {
        alive = false;
        zombieAnimator.Play("Die");
    }

    private void Attack()
    {
        alive = false;
        zombieAnimator.Play("Attack");
    }

    private void LateUpdate()
    {
        if (moving && alive)
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
        moving = true;
    }
}
