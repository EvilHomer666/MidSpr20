using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    [SerializeField] float fireRate;
    [SerializeField] GameObject enemyProjectile;
    [SerializeField] Transform enemyFireSpawn;
    private AudioSource audioSource;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Attack", delay, fireRate);
    }

    // Custom method for enemy to attack player with a projectile
        void Attack()
    {
            // Instantiate enemy projectile at enemy position and play SFX
            Instantiate(enemyProjectile, enemyFireSpawn.position, enemyFireSpawn.rotation);
            audioSource.Play();
    }
}
