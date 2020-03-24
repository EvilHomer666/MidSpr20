using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMotion : MonoBehaviour
{
    // Projectile speeds
    [SerializeField] float speedLv01 = 3.5f;
    private Rigidbody enemyProjectileRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the game objects rigid bodies to apply movement
        enemyProjectileRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        enemyProjectileRb.velocity = Vector3.left * speedLv01;
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            Vector3 hommingTowardsPlayer = (player.transform.position - transform.position).normalized;
            enemyProjectileRb.AddForce(hommingTowardsPlayer * speedLv01);
        }
    }
}
