using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject playerExplosion;
    public int playerCurrentHitPoints;
    private int playerMaxHitPoints = 4;
    private bool hasSpeedPowerUp;

    private GameManager gameManager;
    private SoundManager soundManager;
    private PlayerController speedBoost;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Managers references

        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        speedBoost = GetComponent<PlayerController>();

        hasSpeedPowerUp = false; // << TO DO: to be used with player's speed power up
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHitPoints >= 4)
        {
            hasSpeedPowerUp = true;
            playerCurrentHitPoints = playerMaxHitPoints;
        }

        if(playerCurrentHitPoints <= 3)
        {
            speedBoost.playerCurrentSpeed = playerCurrentHitPoints;
        }

        // Particle system/engine health mechanic
        if (playerCurrentHitPoints == 4 && hasSpeedPowerUp == true)
        {
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
        if (playerCurrentHitPoints == 3)
        {
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
        if (playerCurrentHitPoints == 2)
        {
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
        if (playerCurrentHitPoints == 1)
        {
            GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Play();
        }
      
        // Player Game Over check
        if (playerCurrentHitPoints < 1)
        {
            // Instantiate VFX and SFX on player death
            Instantiate(playerExplosion, transform.position, transform.rotation);
            GameObject.Find("ParticleBurst").GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);                      

            // System pause using coroutine before stopping game
            gameManager.GameOver();            
        }        
    }

    // On trigger enter function to detect collisions with enemy/hazard and take damage
    private void OnTriggerEnter(Collider other)
    {
        // Enemies and hazard damage check
        if (other.gameObject.tag == "EnemyShip" || other.gameObject.tag == "EnemyProjectile")
        {
            Debug.Log("Collision!");
            playerCurrentHitPoints -= 1;
            Destroy(other.gameObject);
            soundManager.PlayerShieldDamage();
        }

        if (other.gameObject.tag == "Hazard") 
        {
            Debug.Log("Collision!");
            playerCurrentHitPoints -= 2; // << Hazards have a larger damage value
            Destroy(other.gameObject);
            soundManager.PlayerShieldDamage();
        }

        if (other.gameObject.tag == "Health")
        {
            Debug.Log("Power Up!");
            playerCurrentHitPoints += 1;
            Destroy(other.gameObject);
            soundManager.PlayerShieldUp();
        }

        if (other.gameObject.tag == "Speed" && playerCurrentHitPoints == 3)
        {
            Debug.Log("Speed Up!");
            playerCurrentHitPoints += 1;
            Destroy(other.gameObject);
            speedBoost.playerSpeed = 15.0f;
            soundManager.PlayerSpeedBoost();
        }
    }
}

