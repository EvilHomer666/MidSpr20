using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Spawn manager array for enemies
    public GameObject[] enemyPrefabs;

    private float spawnPosX = 20f;
    private float spawnRangeY = 13.0f;
    private float spawnPosZ = -3.0f;

    [SerializeField] float startDelay = 2;
    [SerializeField] float spawnInterval = 1;


    // Start is called before the first frame update
    void Start()
    {
        // Method to call a function at a certain time

        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Custom function to spawn random enemy

    void SpawnRandomEnemy()
    {
        // Randomly generate enemies
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, Random.Range (-spawnRangeY, spawnRangeY), spawnPosZ);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
