using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float startDelay = 1.75f;
    private float spawnPosX = 15f;
    private float spawnRangeY = 7f;
    private float spawnPosZ = -9.3f;
    public float spawnInterval = 0.5f;

    // Spawn manager array for enemies
    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        // Method to call a function at a certain time
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    // Custom functions to spawn random enemies and power ups

    void SpawnRandomEnemy()
    {
        // Randomly generate enemies
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, Random.Range (-spawnRangeY, spawnRangeY), spawnPosZ);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
