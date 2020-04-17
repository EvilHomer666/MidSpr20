using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Spawn manager array for enemies
    public GameObject[] enemyPrefabs;

    private float spawnPosX = 18.5f;
    private float spawnRangeY = 11f;
    private float spawnPosZ = -9.3f;

    [SerializeField] float startDelay = 1.75f;
    [SerializeField] float spawnInterval = 0.5f;

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

    // Custom functions to spawn random enemies and power ups

    void SpawnRandomEnemy()
    {
        // Randomly generate enemies
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(spawnPosX, Random.Range (-spawnRangeY, spawnRangeY), spawnPosZ);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
