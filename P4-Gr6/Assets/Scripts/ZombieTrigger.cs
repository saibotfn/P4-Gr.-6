using UnityEngine;
using UnityEngine.InputSystem;

public class ZombieTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Animator animation;
    [SerializeField] GameObject triggerObject;
    private InputSystem_Actions inputActions;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
    }
    void Start()
    {
        animation = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == triggerObject)
        {
            animation.Play("Attack");
        }
    }
    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.player.Jump.performed += ctx => animation.Play("Die");
    }
}
