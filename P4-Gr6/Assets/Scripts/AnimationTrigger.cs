using System;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    Animator anima;
    [SerializeField] GameObject triggerObject;

    void Awake()
    {
        
    }
    void Start()
    {
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            anima.Play("Attack");
        }
    }
}
