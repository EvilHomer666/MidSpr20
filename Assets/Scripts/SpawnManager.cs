using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Spawn manager array and other variables
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 19;
    private float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Method to call a function at a certain time - in this case every 2 seconds, then every 1.5 seconds

        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Custom function to spawn random enemy

    void SpawnRandomEnemy()
    {
        // Randomly generate enemy index and spawn position
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
