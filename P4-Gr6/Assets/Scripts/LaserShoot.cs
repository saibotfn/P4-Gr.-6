using UnityEngine;
using System.Collections;

public class LaserShoot : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float laserSpeed = 40f;
    [SerializeField] private float laserLength = 2f;
    [SerializeField] private float laserWidth = 0.08f;
    [SerializeField] private GameObject laserPrefab;

    private Coroutine laserCoroutine;

    public void Awake()
    {
        lineRenderer.enabled = false;
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
    }

    public void Shoot(Vector3 startPoint, Vector3 endPoint, UnityEngine.Color color)
    { 
        UnityEngine.Debug.Log("startPoint: " + startPoint + ", endPoint: " + endPoint);

        
        //if (laserCoroutine != null)
        //{
            //StopCoroutine(laserCoroutine);
        //}
        //lineRenderer.startColor = color;
        //lineRenderer.endColor = color;

        GameObject laser = Instantiate(laserPrefab, startPoint, Quaternion.identity);
            laser.GetComponent<pewpew>().startPoint = startPoint;
            laser.GetComponent<pewpew>().endPoint = endPoint;
            laser.GetComponent<pewpew>().color = color;
    
            //laserCoroutine = StartCoroutine(MoveLaser(startPoint, endPoint, color));

        //laserCoroutine = StartCoroutine(MoveLaser(startPoint, endPoint));
    }

    private IEnumerator MoveLaser(Vector3 startPoint, Vector3 endPoint)
    {
       lineRenderer.enabled = true;

       Vector3 direction = (endPoint - startPoint).normalized;
       float distance = Vector3.Distance(startPoint, endPoint);
       float travelled = 0f;

       while(travelled < distance)
       {
          travelled += laserSpeed * Time.deltaTime;

          Vector3 front = startPoint + direction * travelled;
          Vector3 back = startPoint + direction * Mathf.Max(travelled - laserLength, 0f);

          lineRenderer.SetPosition(0, back);
          lineRenderer.SetPosition(1, front);

          yield return null;
       }

       lineRenderer.enabled = false;
    }
}
