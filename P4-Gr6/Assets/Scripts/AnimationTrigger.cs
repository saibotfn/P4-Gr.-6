using System;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    Animator anima;
    //[SerializeField] GameObject triggerObject;
    private GameObject TriggerObject;

    void Awake()
    {
        
    }
    void Start()
    {
        anima = GetComponent<Animator>();
        TriggerObject = GameObject.Find("TriggerZoneZombieDie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        anima.Play("Attack");
        Debug.Log("Trigger Entered");
        //if (other.gameObject == TriggerObject)
        
    }
}
