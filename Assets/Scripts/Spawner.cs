using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject GAlien;
    public GameObject LAlien;

    public int SpawnPerSecond = 10;
    public int StarSpawntIn = 30;

    int spawnCount;

    int randomEnemy;

    private int spawnIndex;
    private Transform[] spawnpoints;
    private Vector3 spawnPos;
    private int count;

    void Start()
    {
        count = transform.childCount;
        spawnpoints = new Transform[count];
        for (int i = 0; i < count; i++)
        {
            spawnpoints[i] = transform.GetChild(i);
        }

        InvokeRepeating("spawnEnemys", StarSpawntIn, SpawnPerSecond);
    }

    void spawnEnemys()
    {
        spawnIndex = Random.Range(0, count);

        randomEnemy = Random.Range(1, 5);

        if (randomEnemy == 2)
        {
            GameObject enemy = LAlien;
            float x = Random.Range(0f, 0.5f);
            float z = Random.Range(0f, 0.5f);
            spawnPos = new Vector3(spawnpoints[spawnIndex].position.x + x, spawnpoints[spawnIndex].position.y, spawnpoints[spawnIndex].position.z + z);
            Instantiate(enemy, spawnPos, enemy.transform.rotation);
        }
        else
        {
            GameObject enemy = GAlien;
            float x = Random.Range(0f, 0.5f);
            float z = Random.Range(0f, 0.5f);
            spawnPos = new Vector3(spawnpoints[spawnIndex].position.x + x, spawnpoints[spawnIndex].position.y, spawnpoints[spawnIndex].position.z + z);
            Instantiate(enemy, spawnPos, enemy.transform.rotation);
        }

        spawnCount++;
        Debug.Log("Spawn: " + spawnCount);
    }
}
