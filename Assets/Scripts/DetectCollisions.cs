﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private EnemyMovement stopEnemyMovement;
    private GameManager addScore;

    // Start is called before the first frame update
    void Start()
    {
        // Reference scripts
        stopEnemyMovement = GetComponent<EnemyMovement>();
        addScore = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // On trigger enter function over-ride - Destroy target and projectile on collision
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("Target Hit!");
            stopEnemyMovement.enabled = false;
            //stopCollision.enabled = false;

            // Get access to the instance's rigid body
            Rigidbody rb = GetComponent<Rigidbody>();

            addScore.score += 1;
            Destroy(gameObject);
            Destroy(other.gameObject);


        }
    }
}
