using UnityEngine;
using System.Collections;

public class LaserShoot : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float laserActiveTime;
    [SerializeField] private Vector3 laserOffset = Vector3.zero;

    public void Shoot(Vector3 startPoint, Vector3 endPoint, bool zombieHit)
    { 
        GameObject newLaser = Instantiate(laserPrefab);
        pewpew laser = newLaser.GetComponent<pewpew>();
        laser.activeTime = laserActiveTime;
        laser.setLaser(startPoint, endPoint, zombieHit, laserOffset);
    }


}
