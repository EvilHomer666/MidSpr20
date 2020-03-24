using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Set score defaults
        score = 0;
        UpdateScoreText();
    }

    public void IncrementScore(int updatedScore)
    {
        score += updatedScore;
        UpdateScoreText();
    }

    // Update is called once per frame
    public void UpdateScoreText()
    {
        scoreText.text = $"Score: {score}";
    }
}
