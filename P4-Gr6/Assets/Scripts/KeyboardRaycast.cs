using UnityEngine;

public class KeyboardRaycast : MonoBehaviour
{
    [SerializeField] private Transform[] rayPoints = new Transform[0];
    [SerializeField] private int rayCastRange = 100;
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private float lineLocation = 0f;
    [SerializeField] private float lineBuffer = 0f;
    [SerializeField] private int perfektHitValue = 0;
    [SerializeField] private int perfektHitBonus = 0;

    [SerializeField] private Vector3 laserOffset = new Vector3(0f, 0f, 0f);
    [SerializeField] private LaserShoot laserShoot;

    public void shootRay(int midiValue)
    {
        RaycastHit hit;
        Vector3 rayDirection = new Vector3(1f, 0f, 0f);
        int rayCastIndex = 0;

        switch (midiValue)
        {
            case 36: //White
                rayCastIndex = 0;
                break;
            case 37: //Black
                rayCastIndex = 0;
                break;
            case 38: //White
                rayCastIndex = 1;
                break;
            case 39: //Black
                rayCastIndex = 1;
                break;
            case 40: //White
                rayCastIndex = 2;
                break;
            case 41: //White
                rayCastIndex = 3;
                break;
            case 42: //Black
                rayCastIndex = 3;
                break;
            case 43: //White
                rayCastIndex = 4;
                break;
            case 44: //Black
                rayCastIndex = 4;
                break;
            case 45: //White
                rayCastIndex = 5;
                break;
            case 46: //Black
                rayCastIndex = 5;
                break;
            case 47: //White
                rayCastIndex = 6;
                break;
            case 48: //White
                rayCastIndex = 7;
                break;
            case 49: //Black
                rayCastIndex = 7;
                break;
            case 50: //White
                rayCastIndex = 8;
                break;
            case 51: //Black
                rayCastIndex = 8;
                break;
            case 52: //White
                rayCastIndex = 9;
                break;
            case 53: //White
                rayCastIndex = 10;
                break;
            case 54: //Black
                rayCastIndex = 10;
                break;
            case 55: //White
                rayCastIndex = 11;
                break;
            case 56: //Black
                rayCastIndex = 11;
                break;
            case 57: //White
                rayCastIndex = 12;
                break;
            case 58: //Black
                rayCastIndex = 12;
                break;
            case 59: //White
                rayCastIndex = 13;
                break;
            case 60: //White
                rayCastIndex = 14;
                break;
            case 61: //Black
                rayCastIndex = 14;
                break;
            case 62: //White
                rayCastIndex = 15;
                break;
            case 63: //Black
                rayCastIndex = 15;
                break;
            case 64: //White
                rayCastIndex = 16;
                break;
            case 65: //White
                rayCastIndex = 17;
                break;
            case 66: //Black
                rayCastIndex = 17;
                break;
            case 67: //White
                rayCastIndex = 18;
                break;
            case 68: //Black
                rayCastIndex = 18;
                break;
            case 69: //White
                rayCastIndex = 19;
                break;
            case 70: //Black
                rayCastIndex = 19;
                break;
            case 71: //White
                rayCastIndex = 20;
                break;
            case 72: //White
                rayCastIndex = 21;
                break;
            case 73: //Black
                rayCastIndex = 21;
                break;
            case 74: //White
                rayCastIndex = 22;
                break;
            case 75: //Black
                rayCastIndex = 22;
                break;
            case 76: //White
                rayCastIndex = 23;
                break;
            case 77: //White
                rayCastIndex = 24;
                break;
            case 78: //Black
                rayCastIndex = 24;
                break;
            case 79: //White
                rayCastIndex = 25;
                break;
            case 80: //Black
                rayCastIndex = 25;
                break;
            case 81: //White
                rayCastIndex = 26;
                break;
        }

        if (Physics.Raycast(rayPoints[rayCastIndex].position, rayDirection, out hit, rayCastRange))
        {
            laserShoot.Shoot(rayPoints[rayCastIndex].position + laserOffset, hit.point, UnityEngine.Color.green);

            Destroy(hit.collider.gameObject);
            scoreManager.AddHit();
            scoreManager.AddHP();

            float zombieDistance = hit.transform.position.x - rayPoints[rayCastIndex].position.x;
            if(zombieDistance < lineLocation - lineBuffer)
            {
                scoreManager.AddScore(perfektHitValue - (int)(lineLocation - zombieDistance));
            }
            else if(zombieDistance > lineLocation + lineBuffer)
            {
                scoreManager.AddScore(perfektHitValue - (int)(zombieDistance - lineLocation));
            }
            else
            {
                scoreManager.AddScore(perfektHitValue + perfektHitBonus);
            }

            return;
        }
        else
        {
            Vector3 endPoint = rayPoints[rayCastIndex].position + laserOffset + rayDirection * rayCastRange;
            laserShoot.Shoot(rayPoints[rayCastIndex].position + laserOffset, endPoint, UnityEngine.Color.red);
            
            scoreManager.AddMiss();
            scoreManager.RemoveHP();
        }

        return;
    }
}
