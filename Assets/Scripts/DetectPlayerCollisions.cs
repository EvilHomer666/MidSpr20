using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollisions : MonoBehaviour
{
    private PlayerController stopPlayerMovement;

    // Player hit points
    public int maxHitPoints = 3; 
    public int currentHitPoints;

    // Start is called before the first frame update
    void Start()
    {
        // Reference scripts
        stopPlayerMovement = GetComponent<PlayerController>();

        // Set hit points value at start
        currentHitPoints = maxHitPoints;
    }

    // On trigger enter function over-ride - Destroy target and projectile on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShip, Hazard, EnemyFire") // TO DO << add enemy ability to shit at player
        {
            Debug.Log("Collision!");

            //stopCollision.enabled = false;

            // Get access to the instance's rigid body
            //Rigidbody rb = GetComponent<Rigidbody>();

            currentHitPoints -= 1;
            Destroy(other.gameObject);
        }

        else if (currentHitPoints < 1)
        {
            stopPlayerMovement.enabled = false;
            Destroy(gameObject);
            GameObject.Find("ParticleBurst").GetComponent<ParticleSystem>().Play();
            Debug.Log("You're dead!)");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Particle system/engine health mechanic

        if (currentHitPoints == 3)
        {
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
        if (currentHitPoints == 2)
        {
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Play();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Stop();
        }
        if (currentHitPoints == 1)
        {
            GameObject.Find("enginesLv3").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv2").GetComponent<ParticleSystem>().Stop();
            GameObject.Find("enginesLv1").GetComponent<ParticleSystem>().Play();
        }
    }
}

