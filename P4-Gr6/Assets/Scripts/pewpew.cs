using UnityEngine;
using System.Collections;


public class pewpew : MonoBehaviour
{
    public float activeTime;
    [SerializeField] private Material materialHit;
    [SerializeField] private Material materialMiss;

    private float timeSinceSpawn = 0;


    public void setLaser(Vector3 startPoint, Vector3 endPoint, bool zombieHit, Vector3 offset)
    {
        if (zombieHit)
        {
            GetComponent<MeshRenderer>().material = materialHit;
        }
        else
        {
            GetComponent<MeshRenderer>().material = materialMiss;
        }


        transform.position = new Vector3((startPoint.x + endPoint.x)/2, startPoint.y + offset.y, startPoint.z);
        transform.localScale = new Vector3(endPoint.x - startPoint.x, transform.localScale.y + offset.y, transform.localScale.z);
    }

    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= activeTime)
        {
            Destroy(gameObject);
        }
    }
}
