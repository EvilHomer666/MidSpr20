using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // UI
    [SerializeField] Text gameOverText;
    [SerializeField] Text tryAgainText;

    private bool gameOver;
    private bool tryAgain;

    // Reference to player status
    private DetectPlayerCollisions playerStatus;

    // Start is called before the first frame update
    void Start()
    {
        // Reference to script s
        playerStatus = GetComponent<DetectPlayerCollisions>();

        // Set UI defaults
        gameOver = false;
        tryAgain = false;
        gameOverText.text = "";
        tryAgainText.text = "";
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
                SceneManager.LoadScene("MainMenu");
                // SceneManager.LoadScene(SceneManager.GetSceneByName("HighScores")); TO DO << load scores screen after game over after 5 seconds

            }
        }
    }

    public void GameOver()
    {
        // Game Over condition
        if (playerStatus.playerCurrentHitPoints < 1)
        {
            gameOver = true;

            Debug.Log("Game Over!");
            // << TO DO add try again/game over update screen
        }
    }
}
