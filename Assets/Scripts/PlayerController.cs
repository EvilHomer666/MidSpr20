using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement variables
    [SerializeField] Transform cannonSpawn;
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10.0f;
    private float xRange = 14.8f;
    private float yRange = 13.0f;
    private AudioSource audioSource;

    // Weapons array
    public Transform[] cannons;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for horizontal & vertical player movement boundaries
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if (transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }


        // Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.back * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);


        // Projectile launch condition with for each element to read array
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var projectile in cannons)
            {
                Instantiate(projectile, cannonSpawn.position, cannonSpawn.rotation);
            }
            GetComponent<AudioSource>().Play();
        }
    }
}
