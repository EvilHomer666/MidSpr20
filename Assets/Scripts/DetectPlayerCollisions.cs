using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject playerExplosion;
    public int playerCurrentHitPoints;
    public int playerMaxHitPoints;
    private GameManager gameManager;
    private SoundManager soundManager;
    private PlayerController polarityModifierSwitch;


    // Start is called before the first frame update
    void Start()
    {
        // Initialize Manager references
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        polarityModifierSwitch = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Particle system/engine health mechanic
        while(gameManager.gameOver != true)
        {
            if (playerCurrentHitPoints == 4)
            {
                GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Play();
                GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
                polarityModifierSwitch.polarityModifier = true;
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
            break;
        }       
    }

    // On trigger enter function to detect collisions with enemy/hazard and take damage
    private void OnTriggerEnter(Collider other)
    {
        // Enemies and hazard damage check
        if (other.gameObject.tag == "EnemyShip" || other.gameObject.tag == "EnemyProjectile" || 
            other.gameObject.tag == "Hazard" || other.gameObject.tag == "HazardSP" || other.gameObject.tag == "HazardHP")
        {
            Debug.Log("Collision!");
            playerCurrentHitPoints -= 1;
            Destroy(other.gameObject);
            soundManager.PlayerShieldDamage();

            if (playerCurrentHitPoints <= 1)
            {
                soundManager.PlayerDangerWarning();
            }
        }

        // Check to never let player have more than allowed hit points 
        if (playerCurrentHitPoints > playerMaxHitPoints)
        {
            playerCurrentHitPoints = playerMaxHitPoints;
        }
    }
}

