using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // PowerUp speed
    [SerializeField] float speedBoostValue;
    [SerializeField] float powerUpSpeed;
    [SerializeField] int scoreValue;
    [SerializeField] int healthValue;
    private ScoreManager scoreManager;
    private SpawnManager spawnManager;
    private SoundManager soundManager;
    private DetectPlayerCollisions playerCollisions;
    private PlayerController playerControllerSpeedBoost;
    private float enemySpawnInterval = 0.8f;
    private float playerSpeedCap = 25;
    public LifeBar lifeBar;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script - NOTE TO SELF: REMEMBER HOW TO DO THIS USING GameObject WHEN 
        // LOOKING IN SCRIPTS BUT NOT IN THE SAME GAME OBJECT!!!!
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        GameObject spawnManagerObject = GameObject.FindWithTag("SpawnManager");
        spawnManager = spawnManagerObject.GetComponent<SpawnManager>();

        playerCollisions = FindObjectOfType<DetectPlayerCollisions>();

        playerControllerSpeedBoost = FindObjectOfType<PlayerController>();

        lifeBar = FindObjectOfType<LifeBar>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move power-up to the left
        transform.Translate(Vector3.left * Time.deltaTime * powerUpSpeed);
    }

    // On trigger enter function over-ride - Destroy power up on collision player NOTE TO SELF: None of this will work without colliders set to trigger - must revise, it's buggy.
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Health" && other.gameObject.tag == "Player" && playerCollisions.playerCurrentHitPoints < playerCollisions.playerMaxHitPoints)
        {
            playerCollisions.playerCurrentHitPoints += healthValue;
            lifeBar.SetLife(playerCollisions.playerCurrentHitPoints);
            spawnManager.spawnInterval *= enemySpawnInterval;
            soundManager.PlayerShieldUp();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Power Up!");
        }

        else if (gameObject.tag == "Health" && other.gameObject.tag == "Player" && playerCollisions.playerCurrentHitPoints == playerCollisions.playerMaxHitPoints)
        {
            playerCollisions.playerCurrentHitPoints = playerCollisions.playerMaxHitPoints;
            spawnManager.spawnInterval *= enemySpawnInterval;
            soundManager.PlayerCollectedPowerUp();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Pick Up!");
        }

        if (gameObject.tag == "Speed" && other.gameObject.tag == "Player" && playerControllerSpeedBoost.playerSpeed < playerSpeedCap)
        {
            playerControllerSpeedBoost.UpdatePlayerSpeed(speedBoostValue);
            spawnManager.spawnInterval *= enemySpawnInterval;
            soundManager.PlayerSpeedBoost();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Speed Up!");
        }

        else if (gameObject.tag == "Speed" && other.gameObject.tag == "Player" && playerControllerSpeedBoost.playerSpeed == playerSpeedCap)
        {
            playerControllerSpeedBoost.playerSpeed = playerSpeedCap;
            spawnManager.spawnInterval *= enemySpawnInterval;
            soundManager.PlayerCollectedPowerUp();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Pick Up!");
        }
    }
}

