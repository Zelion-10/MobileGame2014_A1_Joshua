using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int lives = 3; // Total lives for the player
    public GameObject gameOverUI; // Reference to Game Over UI
    public string sceneToLoad = "GameOverScene"; // Name of the scene to load when player dies
    public TMP_Text livesText; // Reference to the UI Text component

    private void Start()
    {
        UpdateLivesDisplay(); // Update the display at the start
    }

    // Method to reduce lives
    public void TakeDamage()
    {
        lives--;
        Debug.Log("Lives left: " + lives);

        // Update the UI
        UpdateLivesDisplay();

        // Check if player is still alive
        if (lives <= 0)
        {
            Die();
        }
    }

    // Update the UI Text
    private void UpdateLivesDisplay()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + lives; // Update the displayed text
        }
    }

    // Handle player death
    private void Die()
    {
        Debug.Log("Game Over!");
        gameObject.SetActive(false);

        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
