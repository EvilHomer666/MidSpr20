using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // PowerUp speed
    [SerializeField] float powerUpSpeed = 2f;
    [SerializeField] int powerUpHPValue = 1;
    public int scoreValue;

    //private ScoreManager scoreManager;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to GameManager script - NOTE TO SELF: REMEMBER HOW TO DO THIS USING GameObject WHEN 
        // LOOKING IN SCRIPTS BUT NOT IN THE SAME GAME OBJECT!!!!
        GameObject scoreManagerObject = GameObject.FindWithTag("Score Manager");
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * powerUpSpeed);
    }

    // On trigger enter function over-ride - Destroy power up on collision player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            scoreManager.IncrementScore(scoreValue);
        }
    }
}
