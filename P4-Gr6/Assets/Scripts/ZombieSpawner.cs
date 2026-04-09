using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints = new GameObject[0];
    [SerializeField] private GameObject zombiePrefab_White;
    [SerializeField] private GameObject zombiePrefab_Black;


    private int treble;
    private int bass;

    public void SpawnZombie(List<int> spawnIndex)
    {
        foreach (int i in spawnIndex)
        {
            switch (i)
            {
                case 36: //White
                    Instantiate(zombiePrefab_White, spawnPoints[0].transform.position, Quaternion.identity);
                    break;
                case 37: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[0].transform.position, Quaternion.identity);
                    break;
                case 38: //White
                    Instantiate(zombiePrefab_White, spawnPoints[1].transform.position, Quaternion.identity);
                    break;
                case 39: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[1].transform.position, Quaternion.identity);
                    break;
                case 40: //White
                    Instantiate(zombiePrefab_White, spawnPoints[2].transform.position, Quaternion.identity);
                    break;
                case 41: //White
                    Instantiate(zombiePrefab_White, spawnPoints[3].transform.position, Quaternion.identity);
                    break;
                case 42: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[3].transform.position, Quaternion.identity);
                    break;
                case 43: //White
                    Instantiate(zombiePrefab_White, spawnPoints[4].transform.position, Quaternion.identity);
                    break;
                case 44: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[4].transform.position, Quaternion.identity);
                    break;
                case 45: //White
                    Instantiate(zombiePrefab_White, spawnPoints[5].transform.position, Quaternion.identity);
                    break;
                case 46: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[5].transform.position, Quaternion.identity);
                    break;
                case 47: //White
                    Instantiate(zombiePrefab_White, spawnPoints[6].transform.position, Quaternion.identity);
                    break;
                case 48: //White
                    Instantiate(zombiePrefab_White, spawnPoints[7].transform.position, Quaternion.identity);
                    break;
                case 49: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[7].transform.position, Quaternion.identity);
                    break;
                case 50: //White
                    Instantiate(zombiePrefab_White, spawnPoints[8].transform.position, Quaternion.identity);
                    break;
                case 51: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[8].transform.position, Quaternion.identity);
                    break;
                case 52: //White
                    Instantiate(zombiePrefab_White, spawnPoints[9].transform.position, Quaternion.identity);
                    break;
                case 53: //White
                    Instantiate(zombiePrefab_White, spawnPoints[10].transform.position, Quaternion.identity);
                    break;
                case 54: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[10].transform.position, Quaternion.identity);
                    break;
                case 55: //White
                    Instantiate(zombiePrefab_White, spawnPoints[11].transform.position, Quaternion.identity);
                    break;
                case 56: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[11].transform.position, Quaternion.identity);
                    break;
                case 57: //White
                    Instantiate(zombiePrefab_White, spawnPoints[12].transform.position, Quaternion.identity);
                    break;
                case 58: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[12].transform.position, Quaternion.identity);
                    break;
                case 59: //White
                    Instantiate(zombiePrefab_White, spawnPoints[13].transform.position, Quaternion.identity);
                    break;
                case 60: //White
                    Instantiate(zombiePrefab_White, spawnPoints[14].transform.position, Quaternion.identity);
                    break;
                case 61: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[14].transform.position, Quaternion.identity);
                    break;
                case 62: //White
                    Instantiate(zombiePrefab_White, spawnPoints[15].transform.position, Quaternion.identity);
                    break;
                case 63: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[15].transform.position, Quaternion.identity);
                    break;
                case 64: //White
                    Instantiate(zombiePrefab_White, spawnPoints[16].transform.position, Quaternion.identity);
                    break;
                case 65: //White
                    Instantiate(zombiePrefab_White, spawnPoints[17].transform.position, Quaternion.identity);
                    break;
                case 66: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[17].transform.position, Quaternion.identity);
                    break;
                case 67: //White
                    Instantiate(zombiePrefab_White, spawnPoints[18].transform.position, Quaternion.identity);
                    break;
                case 68: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[18].transform.position, Quaternion.identity);
                    break;
                case 69: //White
                    Instantiate(zombiePrefab_White, spawnPoints[19].transform.position, Quaternion.identity);
                    break;
                case 70: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[19].transform.position, Quaternion.identity);
                    break;
                case 71: //White
                    Instantiate(zombiePrefab_White, spawnPoints[20].transform.position, Quaternion.identity);
                    break;
                case 72: //White
                    Instantiate(zombiePrefab_White, spawnPoints[21].transform.position, Quaternion.identity);
                    break;
                case 73: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[21].transform.position, Quaternion.identity);
                    break;
                case 74: //White
                    Instantiate(zombiePrefab_White, spawnPoints[22].transform.position, Quaternion.identity);
                    break;
                case 75: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[22].transform.position, Quaternion.identity);
                    break;
                case 76: //White
                    Instantiate(zombiePrefab_White, spawnPoints[23].transform.position, Quaternion.identity);
                    break;
                case 77: //White
                    Instantiate(zombiePrefab_White, spawnPoints[24].transform.position, Quaternion.identity);
                    break;
                case 78: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[24].transform.position, Quaternion.identity);
                    break;
                case 79: //White
                    Instantiate(zombiePrefab_White, spawnPoints[25].transform.position, Quaternion.identity);
                    break;
                case 80: //Black
                    Instantiate(zombiePrefab_Black, spawnPoints[25].transform.position, Quaternion.identity);
                    break;
                case 81: //White
                    Instantiate(zombiePrefab_White, spawnPoints[26].transform.position, Quaternion.identity);
                    break;
            }
        }
    }

    
}
