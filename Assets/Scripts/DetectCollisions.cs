using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    [SerializeField] int scoreValue;
    [SerializeField] int enemyHitPoints;
    [SerializeField] bool holdsPowerUp;
    [SerializeField] GameObject powerUpDrop;
    [SerializeField] Transform powerUpSpawn;
    private int damageValue = 1;
    private ScoreManager scoreManager;
    private PlayerAttackMotion projectileImpact;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script - NOTE TO SELF: REMEMBER HOW TO DO THIS USING GameObject WHEN 
        // LOOKING IN SCRIPTS BUT NOT IN THE SAME GAME OBJECT!!!!
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        projectileImpact = FindObjectOfType<PlayerAttackMotion>();
    }

    // On trigger enter function over-ride - Destroy target and projectile on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier") || other.CompareTag("EnemyProjectile"))
        {
            return;
        }

        while (other.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("Target Hit!");
            // projectileImpact.ImpactFX(); // TO DO figure out how to instantiate impact particle effect and not lose it at destroy
            Destroy(other.gameObject);
            enemyHitPoints -= damageValue;

            if (enemyHitPoints <= 0)
            {
                Debug.Log("Target Destroyed!");
                // Add score value of destroyed enemy to score variable in ScoreManager script and destroy player projectile and enemy/hazard
                scoreManager.IncrementScore(scoreValue);
                Destroy(other.gameObject);
                if (gameObject.tag == "HazardHP" || gameObject.tag == "HazardSP")
                {
                    // Spawn power-up drops at enemies last position upon destruction
                    Instantiate(powerUpDrop, powerUpSpawn.position, powerUpSpawn.localRotation);
                }
                Destroy(gameObject);
            }
            break;
        } 
    }
}
