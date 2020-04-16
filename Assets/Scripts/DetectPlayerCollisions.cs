using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject playerExplosion;
    public float playerCurrentHitPoints;
    private int playerCurrentSpeed;
    private int playerMaxSpeed = 25;
    public bool hasSpeedPowerUp;

    private GameManager gameManager;
    private SoundManager soundManager;

    public float playerMaxHitPoints = 4;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Managers references

        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        hasSpeedPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHitPoints > playerMaxHitPoints)
        {
            playerCurrentHitPoints = playerMaxHitPoints;
        }

        if (playerCurrentHitPoints <= 3)
        {
            hasSpeedPowerUp = false;
        }

        // Particle system/engine health mechanic
        if (playerCurrentHitPoints == 3 && hasSpeedPowerUp == true)
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
        if (playerCurrentHitPoints <= 0)
        {
            // Instantiate VFX and SFX on player death
            Instantiate(playerExplosion, transform.position, transform.rotation);
            GameObject.Find("ParticleBurst").GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);                      
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

            if (playerCurrentHitPoints == 1)
            {
                soundManager.PlayerDangerWarning();
            }
        }

        if (other.gameObject.tag == "Hazard" || other.gameObject.tag == "HazardSP" || other.gameObject.tag == "HazardHP") 
        {
            Debug.Log("Collision!");
            playerCurrentHitPoints -= 2; // << Hazards have a larger damage value
            Destroy(other.gameObject);
            soundManager.PlayerShieldDamage();

            if (playerCurrentHitPoints == 1)
            {
                soundManager.PlayerDangerWarning();
            }
        }
    }
}

