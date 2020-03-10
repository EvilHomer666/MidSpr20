using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Enemy speed
    [SerializeField] float enemySpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * enemySpeed);
    }
}
