using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } 

    private int score = 0; 

    [SerializeField]
    private TextMeshProUGUI scoreText; 

    private void Awake()
    {
        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist this object across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instance
        }
    }

    public void ChangeScore(int amount)
    {
        score += amount; // Change the score by the given amount
        UpdateScore(); // Update the displayed score
    }

    public int GetScore()
    {
        return score; // Get the current score
    }

    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the score text in the UI
        }
    }

    public void SetScoreText(TextMeshProUGUI text)
    {
        scoreText = text; // Set the score text reference from other scripts if needed
        UpdateScore(); // Initialize the display
    }
}
