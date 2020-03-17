using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Enemy hit point variables
    [SerializeField] int enemyHitPoints;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // On trigger enter function over-ride - Destroy target and projectile on collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerProjectile")
        {
            Debug.Log("Target Hit!");
            Destroy(other.gameObject);
            //fullHitPoints -= 1;
            enemyHitPoints -= 1;
        }
        if(enemyHitPoints < 1)
        {
            Debug.Log("Target Destroyed!");
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
    }
}
