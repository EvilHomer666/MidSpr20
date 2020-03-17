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

    private bool tryAgain;
    private bool gameOver;

    private DetectPlayerCollisions playerStatus;
    private ScoreManager currentScore;

    // Start is called before the first frame update
    void Start()
    {
        // Set UI defaults
        
        gameOver = false;
        tryAgain = false;
        gameOverText.text = "";
        tryAgainText.text = "";
        quitGameText.text = "";
        scoreText.text = "";

        // Reference to player collisions script
        playerStatus = GetComponent<DetectPlayerCollisions>();
        currentScore = GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Game Over and Continue checks

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

    // Custom method to update text for score/damage
    public void incrementScore()
    {
        UpdateUI(); // TO DO <<< Update the UI when game over

        // Game Over condition
        if (playerStatus.playerCurrentHitPoints < 1)
        {
            Debug.Log("Game Over!");
           // SceneManager.LoadScene(SceneManager.GetSceneByName("HighScores")); TO DO << load scores screen after game over after 5 seconds
        }
    }

    // Custom method to update text for score and win/game over
    public void UpdateUI()
    {
        // << TO DO add game over update screen
    }

    public void UpdateScore()
    {
        scoreText.text = $"{currentScore}";
    }
}
