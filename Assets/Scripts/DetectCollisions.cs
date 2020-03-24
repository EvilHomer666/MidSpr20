﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Enemy hit point variables
    [SerializeField] int enemyHitPoints;
    public int scoreValue;

    //private ScoreManager scoreManager;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script - NOTE TO SELF: REMEMBER HOW TO DO THIS USING GameObject WHEN 
        // LOOKING IN SCRIPTS NOT IN THE SAME GAME OBJECT!!!!
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // On trigger enter function over-ride - Destroy target and projectile on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("Target Hit!");
            Destroy(other.gameObject);
            enemyHitPoints -= 1;
        }
        if(enemyHitPoints < 1)
        {
            Debug.Log("Target Destroyed!");
            // Add score value of destroyed enemy to score variable in ScoreManager script and destroy game objects
            Destroy(gameObject);
            Destroy(other.gameObject);
            scoreManager.IncrementScore(scoreValue);
        }
    }
}
