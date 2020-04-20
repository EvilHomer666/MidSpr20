using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMotion : MonoBehaviour
{
    [SerializeField] GameObject impactExposion;
    [SerializeField] Transform impactSpawn;

    // Projectile speeds
    public float speedLv01 = 40;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speedLv01);
    }

    public void ImpactFX()
    {
        Instantiate(impactExposion, impactSpawn.position, impactSpawn.rotation);
    }
}
