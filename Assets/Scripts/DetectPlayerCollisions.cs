using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayerCollisions : MonoBehaviour
{
    private PlayerController stopPlayerMovement;

    // Start is called before the first frame update
    void Start()
    {
        // Reference scripts
        stopPlayerMovement = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    // On trigger enter function over-ride - Destroy target and projectile on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShip")
        {
            Debug.Log("Collision!");
            stopPlayerMovement.enabled = false;
            //stopCollision.enabled = false;

            // Get access to the instance's rigid body
            Rigidbody rb = GetComponent<Rigidbody>();

            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Hazard")
        {
            Debug.Log("Collision!");
            stopPlayerMovement.enabled = false;
            //stopCollision.enabled = false;

            // Get access to the instance's rigid body
            Rigidbody rb = GetComponent<Rigidbody>();

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

