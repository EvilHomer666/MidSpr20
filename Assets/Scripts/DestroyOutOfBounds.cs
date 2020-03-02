using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Game space boundary limit variables
    private float topBound = 21;
    private float lowerBound = -21;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Condition to check and destroy prefabs at boundaries
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Missed Target");
            Destroy(gameObject);
        }
    }
}
