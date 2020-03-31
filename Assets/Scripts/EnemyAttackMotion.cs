using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackMotion : MonoBehaviour
{
    // Projectile variables
    [SerializeField] float speedLv01;
    [SerializeField] bool homingProjectile;

    //private Transform player;
    private Vector3 target;

    private Rigidbody enemyProjectileRb;
    private GameObject player;

    //private DetectPlayerCollisions playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        // Fetch the game objects rigid bodies to apply movement
        enemyProjectileRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        //playerStatus = GetComponent<DetectPlayerCollisions>();
    }
    // Update is called once per frame
    void Update()
    {
        if (homingProjectile == false && player != null)
        {
            //player = GameObject.FindGameObjectWithTag("Player").transform;

            target = (player.transform.position - transform.position).normalized * speedLv01;

            transform.LookAt(target);
            transform.position += target * speedLv01 * Time.deltaTime;

        }

        if (homingProjectile == true && player != null)
        {
            // Homing projectile
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyProjectileRb.AddForce(lookDirection * speedLv01);
        }
    }
}
