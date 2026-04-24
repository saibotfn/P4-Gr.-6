using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints = new GameObject[0];
    [SerializeField] private GameObject zombiePrefab_White;
    [SerializeField] private GameObject zombiePrefab_Black;
    [SerializeField] private GameObject zombiePrefab;

    [SerializeField] private Vector3 zombieOffset;
    private Quaternion zombieRotation;

    private int treble;
    private int bass;

    private void Start()
    {
        zombieRotation = Quaternion.Euler(0, -90, 0);
    }

    public void SpawnZombie(List<int> spawnIndex)
    {
        GameObject noteObj = null;
        foreach (int i in spawnIndex)
        {
            switch (i)
            {
                case 36: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[0].transform.position, zombieRotation);
                    break;
                case 37: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[0].transform.position, zombieRotation);
                    break;
                case 38: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[1].transform.position, zombieRotation);
                    break;
                case 39: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[1].transform.position, zombieRotation);
                    break;
                case 40: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[2].transform.position, zombieRotation);
                    break;
                case 41: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[3].transform.position, zombieRotation);
                    break;
                case 42: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[3].transform.position, zombieRotation);
                    break;
                case 43: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[4].transform.position, zombieRotation);
                    break;
                case 44: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[4].transform.position, zombieRotation);
                    break;
                case 45: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[5].transform.position, zombieRotation);
                    break;
                case 46: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[5].transform.position, zombieRotation);
                    break;
                case 47: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[6].transform.position, zombieRotation);
                    break;
                case 48: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[7].transform.position, zombieRotation);
                    break;
                case 49: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[7].transform.position, zombieRotation);
                    break;
                case 50: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[8].transform.position, zombieRotation);
                    break;
                case 51: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[8].transform.position, zombieRotation);
                    break;
                case 52: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[9].transform.position, zombieRotation);
                    break;
                case 53: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[10].transform.position, zombieRotation);
                    break;
                case 54: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[10].transform.position, zombieRotation);
                    break;
                case 55: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[11].transform.position, zombieRotation);
                    break;
                case 56: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[11].transform.position, zombieRotation);
                    break;
                case 57: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[12].transform.position, zombieRotation);
                    break;
                case 58: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[12].transform.position, zombieRotation);
                    break;
                case 59: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[13].transform.position, zombieRotation);
                    break;
                case 60: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[14].transform.position, zombieRotation);
                    break;
                case 61: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[14].transform.position, zombieRotation);
                    break;
                case 62: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[15].transform.position, zombieRotation);
                    break;
                case 63: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[15].transform.position, zombieRotation);
                    break;
                case 64: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[16].transform.position, zombieRotation);
                    break;
                case 65: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[17].transform.position, zombieRotation);
                    break;
                case 66: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[17].transform.position, zombieRotation);
                    break;
                case 67: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[18].transform.position, zombieRotation);
                    break;
                case 68: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[18].transform.position, zombieRotation);
                    break;
                case 69: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[19].transform.position, zombieRotation);
                    break;
                case 70: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[19].transform.position, zombieRotation);
                    break;
                case 71: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[20].transform.position, zombieRotation);
                    break;
                case 72: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[21].transform.position, zombieRotation);
                    break;
                case 73: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[21].transform.position, zombieRotation);
                    break;
                case 74: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[22].transform.position, zombieRotation);
                    break;
                case 75: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[22].transform.position, zombieRotation);
                    break;
                case 76: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[23].transform.position, zombieRotation);
                    break;
                case 77: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[24].transform.position, zombieRotation);
                    break;
                case 78: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[24].transform.position, zombieRotation);
                    break;
                case 79: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[25].transform.position, zombieRotation);
                    break;
                case 80: //Black
                    noteObj = Instantiate(zombiePrefab_Black, spawnPoints[25].transform.position, zombieRotation);
                    break;
                case 81: //White
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[26].transform.position, zombieRotation);
                    break;
                default:
                    noteObj = Instantiate(zombiePrefab_White, spawnPoints[27].transform.position, zombieRotation);
                    break;
            }
            GameObject zombieObj = Instantiate(zombiePrefab, noteObj.transform);
            zombieObj.transform.rotation = zombieRotation;
            zombieObj.transform.position = noteObj.transform.position + zombieOffset;
        }
    }
}
