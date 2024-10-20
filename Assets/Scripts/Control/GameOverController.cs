using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText; // Reference to the UI Text for displaying score

    void Start()
    {
        LoadScore(); // Load the score when the Game Over scene starts
    }

    private void LoadScore()
    {
        int score = PlayerPrefs.GetInt("PlayerScore", 0); // Get score, default to 0
        scoreText.text = "Score: " + score; // Update UI text
    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteKey("PlayerScore"); // Clear score for next game
        SceneManager.LoadScene("GameScene"); // Load the main game scene
    }

    public void LoadMainMenu()
    {
        PlayerPrefs.DeleteKey("PlayerScore"); // Clear score for next game
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
}
