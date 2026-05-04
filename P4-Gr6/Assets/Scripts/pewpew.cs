using UnityEngine;
using System.Collections;


public class pewpew : MonoBehaviour
{
    public float laserSpeed = 40f;
    public float laserLength = 2f;
    public float laserWidth = 0.08f;
    private LineRenderer lineRenderer;

    public Vector3 startPoint;
    public Vector3 endPoint;
    public UnityEngine.Color color;

    public IEnumerator MoveLaser(Vector3 startPoint, Vector3 endPoint, UnityEngine.Color color)
    {
       lineRenderer.enabled = true;

       lineRenderer.startColor = color;
       lineRenderer.endColor = color;

       Vector3 direction = (endPoint - startPoint).normalized;
       float distance = Vector3.Distance(startPoint, endPoint);
       float travelled = 0f;

       while(travelled < distance)
       {
          travelled += laserSpeed * Time.deltaTime;

          Vector3 front = new Vector3(startPoint.x + direction.x * travelled, startPoint.y, startPoint.z);
          Vector3 back = new Vector3(startPoint.x + direction.x * Mathf.Max(travelled - laserLength, 0f), startPoint.y, startPoint.z);

          lineRenderer.SetPosition(0, back);
          lineRenderer.SetPosition(1, front);

          yield return null;
       }

       lineRenderer.enabled = false;

       Destroy(gameObject);
    }

    void Start()
    {
        Debug.Log("pewpew Start called. startPoint: " + startPoint + ", endPoint: " + endPoint);
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;

        StartCoroutine(MoveLaser(startPoint, endPoint, color));
    }

    
    void Update()
    {
        
    }
}
