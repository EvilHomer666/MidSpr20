using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI
    [SerializeField] Text scoreText;
    [SerializeField] Text tryAgainText;
    [SerializeField] Text gameOverText;
    [SerializeField] Text quitGameText;

    public int score; // TO DO << store score in a list for later viewing
    private bool tryAgain;
    private bool gameOver;

    private DetectPlayerCollisions playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        // Set UI defaults
        score = 0;
        gameOver = false;
        tryAgain = false;
        gameOverText.text = "";
        tryAgainText.text = "";
        quitGameText.text = "";

        // Reference to player collisions script
        playerStatus = GetComponent<DetectPlayerCollisions>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver == true)
        {
            // Condition to try again
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            // Condition to quit game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

    }

    // Custom method to increment score/damage
    public void incrementScore()
    {
        UpdateUI();

        // Game Over condition
        if (playerStatus.currentHitPoints < 1)
        {
            Debug.Log("Game Over!");
           // SceneManager.LoadScene(SceneManager.GetSceneByName("HighScores")); TO DO << load scores screen after game over after 5 seconds
        }
    }

    // Custom method to update text
    public void UpdateUI()
    {
        scoreText.text = $"{score}";
    }
}
