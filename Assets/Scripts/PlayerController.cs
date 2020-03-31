using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement variables
    [SerializeField] Transform cannonSpawn;
    private float launchSpeed = 3.0f; // << the speed at which I want the ship to move when it shows on screen moving from left to right
    private float horizontalInput;
    private float verticalInput;
    public float speed = 10.0f;
    private float xRange = 15.8f;
    private float yRange = 11.5f;
    private Rigidbody playerRB;
    private GameObject launchPad;
    private AudioSource audioSource;

    // Weapons array
    public Transform[] cannons;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        launchPad = GameObject.FindGameObjectWithTag("LaunchPad");
        LaunchPlayer();
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

        // Player input movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.back * horizontalInput * Time.deltaTime * speed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);


        // Projectile launch condition with foreach element to read array
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            foreach(var projectile in cannons)
            {
                Instantiate(projectile, cannonSpawn.position, cannonSpawn.rotation);
            }
            GetComponent<AudioSource>().Play();
        }
    }
    private void LaunchPlayer()
    {
        // Player launch movement
        Vector3 lookDirection = (launchPad.transform.position - transform.position).normalized; // << This was the last approach where at least the ship does move.
        playerRB.AddForce(lookDirection * launchSpeed);

    }
}
