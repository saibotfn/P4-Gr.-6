using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPoints = new GameObject[0];
    [SerializeField] private GameObject zombiePrefab;

    private int treble;
    private int bass;

    public void SpawnZombie(List<int> spawnIndex)
    {
        foreach (int i in spawnIndex)
        {
            switch (i)
            {
                case 60:
                    // 14
                    Instantiate(zombiePrefab, spawnPoints[14].transform);
                    break;
                case 62:
                    // 14
                    Instantiate(zombiePrefab, spawnPoints[15].transform);
                    break;
                case 64:
                    // 14
                    Instantiate(zombiePrefab, spawnPoints[16].transform);
                    break;
                default:
                    Instantiate(zombiePrefab_White, spawnPoints[27].transform.position, Quaternion.identity);
                    break;
            }
        }
    }

    
}
