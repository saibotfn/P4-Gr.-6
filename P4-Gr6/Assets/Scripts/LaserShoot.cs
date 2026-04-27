using UnityEngine;
using System.Collections;

public class LaserShoot : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float laserDuration = 0.08f;

    private Coroutine laserCoroutine;

    public void Shoot(Vector3 startPoint, Vector3 endPoint, UnityEngine.Color color)
    { 
        UnityEngine.Debug.Log("startPoint: " + startPoint + ", endPoint: " + endPoint);

        
        if (laserCoroutine != null)
        {
            StopCoroutine(laserCoroutine);
        }
        lineRenderer.startColor = color;
        laserCoroutine = StartCoroutine(ShowLaser(startPoint, endPoint));
    }

    private IEnumerator ShowLaser(Vector3 startPoint, Vector3 endPoint)
    {
       lineRenderer.enabled = true;

       lineRenderer.positionCount = 2;
       lineRenderer.SetPosition(0, startPoint);
       lineRenderer.SetPosition(1, endPoint);

       yield return new WaitForSeconds(laserDuration);

       lineRenderer.enabled = false;
    }
}
