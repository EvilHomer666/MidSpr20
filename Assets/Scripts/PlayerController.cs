using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement variables
    [SerializeField] Transform cannonSpawn;
    private float playerStartSpeed;
    private float xRange = 15.8f;
    private float yRange = 11.5f;
    private float horizontalInput;
    private float verticalInput;
    private SoundManager soundManager;
    private AudioSource audioSource;
    public float playerCurrentSpeed;
    public bool polarityModifier;

    // Weapons array
    public Transform[] cannons;

    // Start is called before the first frame update
    void Start()
    {
        //playerStartSpeed = 10.0f;
        polarityModifier = false; // << TO DO Add player ability to use enemy fire against enemy
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
        transform.Translate(Vector3.back * horizontalInput * Time.deltaTime * playerCurrentSpeed);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * playerCurrentSpeed);

        // Projectile launch condition with for each element to read array
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            foreach(var projectile in cannons)
            {
                Instantiate(projectile, cannonSpawn.position, cannonSpawn.rotation);
            }
            GetComponent<AudioSource>().Play();
        }
    }
}
