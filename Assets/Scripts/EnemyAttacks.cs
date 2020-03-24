using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] Transform enemyFireSpawn;
    [SerializeField] float fireRate;
    [SerializeField] float delay;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Attack", delay, fireRate);
    }

    // Custom method for enemy to attack player with a projectile

        void Attack()
    {
        Instantiate(enemyProjectile, enemyFireSpawn.position, enemyFireSpawn.rotation);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
