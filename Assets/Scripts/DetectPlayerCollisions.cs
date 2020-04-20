using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollisions : MonoBehaviour
{
    [SerializeField] GameObject playerExplosion;
    private int enginesLv1 = 1;
    private int enginesLv2 = 2;
    public int enginesLv3 = 3;
    private int enginesLv4 = 4;
    private int damageValue = 1;
    private GameManager gameManager;
    private SoundManager soundManager;
    public int playerCurrentHitPoints;
    public int playerMaxHitPoints;
    // private PlayerController polarityModifierSwitch; // << TO DO to be implemented with player's ability to use enemy fire against them


    // Start is called before the first frame update
    void Start()
    {
        // Initialize Manager references
        GameObject gameManagerObject = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        GameObject soundManagerObject = GameObject.FindWithTag("SoundManager");
        soundManager = soundManagerObject.GetComponent<SoundManager>();

        // polarityModifierSwitch = FindObjectOfType<PlayerController>(); // << TO DO to be implemented with player's ability to use enemy fire against them
    }

    // Update is called once per frame
    void Update()
    {
        // Particle system/engine health mechanic
        while(gameManager.gameOver != true)
        {
            if (playerCurrentHitPoints == enginesLv4)
            {
                GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Play();
                GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
               // polarityModifierSwitch.polarityModifier = true; // << TO DO to be implemented with player's ability to use enemy fire against them
            }
            if (playerCurrentHitPoints == enginesLv3)
            {
                GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Play();
                GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
            }
            if (playerCurrentHitPoints == enginesLv2)
            {
                GameObject.Find("enginesLv4").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Play();
                GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
            }
            if (playerCurrentHitPoints == enginesLv1)
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
            playerCurrentHitPoints -= damageValue;
            Destroy(other.gameObject);
            soundManager.PlayerShieldDamage();

            if (playerCurrentHitPoints <= damageValue)
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

