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

    // Start is called before the first frame update
    void Start()
    {
        // Set hit points value at start
        gameManager = GetComponent<GameManager>();
        hasSpeedPowerUp = false;
    }

    // Update is called once per frame
    void Update()
    {
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
      
        // Player hit points check
        if (playerCurrentHitPoints < 1)
        {
            // Instantiate VFX and SFX on player death
            Instantiate(playerExplosion, transform.position, transform.rotation);
            GameObject.Find("ParticleBurst").GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            // TO DO << call game over function script
        }
    }

    // On trigger enter function to detect collisions with enemy/hazard and take damage
    private void OnTriggerEnter(Collider other)
    {
        // Enemies and hazard damage check
        if (other.gameObject.tag == "EnemyShip" || other.gameObject.tag == "EnemyProjectile") // TO DO << add enemy ability to shot at player
        {
            Debug.Log("Collision!");
            playerCurrentHitPoints -= 1;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Hazard")
        {
            Debug.Log("Collision!");
            playerCurrentHitPoints -= 2;
            Destroy(other.gameObject);
        }
    }
}

