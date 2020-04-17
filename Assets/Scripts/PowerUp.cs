using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // PowerUp speed
    private float powerUpSpeed = 2f;
    public int scoreValue;

    private ScoreManager scoreManager;
    private SoundManager soundManager;
    private DetectPlayerCollisions playerCollisions;
    private PlayerController playerControllerSpeedBoost;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script - NOTE TO SELF: REMEMBER HOW TO DO THIS USING GameObject WHEN 
        // LOOKING IN SCRIPTS BUT NOT IN THE SAME GAME OBJECT!!!!
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        playerCollisions = FindObjectOfType<DetectPlayerCollisions>();
        playerControllerSpeedBoost = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move power up to the left
        transform.Translate(Vector3.left * Time.deltaTime * powerUpSpeed);
    }

    // On trigger enter function over-ride - Destroy power up on collision player
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Health" && other.gameObject.tag == "Player" && playerCollisions.playerCurrentHitPoints < playerCollisions.playerMaxHitPoints)
        {
            playerCollisions.playerCurrentHitPoints += 1;
            soundManager.PlayerShieldUp();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Power Up!");
        }

        if (gameObject.tag == "Health" && other.gameObject.tag == "Player" && playerCollisions.playerCurrentHitPoints == playerCollisions.playerMaxHitPoints)
        {
            soundManager.PlayerCollectedPowerUp();
            scoreManager.IncrementScore(scoreValue *= 5);
            Destroy(gameObject);
            Debug.Log("Pick Up!");
        }

        if (gameObject.tag == "Speed" && other.gameObject.tag == "Player")
        {
            playerControllerSpeedBoost.playerCurrentSpeed *= 0.5f;
           
            soundManager.PlayerSpeedBoost();
            scoreManager.IncrementScore(scoreValue);
            Destroy(gameObject);
            Debug.Log("Speed Up!");
        }

        //if (gameObject.tag == "Speed" && other.gameObject.tag == "Player" && playerCollisions.playerCurrentHitPoints == 4)
        //{
        //    soundManager.PlayerCollectedPowerUp();
        //    scoreManager.IncrementScore(scoreValue *= 13);
        //    Destroy(gameObject);
        //}
    }
}
