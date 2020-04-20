using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        // Set score defaults
        score = 0;
        UpdateScoreText();
    }

    // Add score value and update text
    public void IncrementScore(int updatedScore)
    {
        score += updatedScore;
        UpdateScoreText();
    }

    // Update score text method
    public void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}
