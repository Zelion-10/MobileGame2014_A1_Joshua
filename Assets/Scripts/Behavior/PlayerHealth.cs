using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes
using TMPro; // For updating UI using TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxLives = 3; // Player's maximum lives
    private int currentLives; // Player's current lives

    [SerializeField]
    private AudioClip hitSFX;  // Sound effect for player hit
    [SerializeField]
    private AudioClip deathSFX; // Sound effect for player death
    private AudioSource audioSource; // Reference to AudioSource for playing sounds

    [SerializeField]
    private TMP_Text livesText; // Reference to the TextMeshPro UI for displaying lives

    private bool isDead = false; // To prevent multiple deaths

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        currentLives = maxLives; // Initialize player with full lives
        UpdateLivesUI(); // Update UI with current lives
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collision with damaging objects (e.g., enemies, hazards)
        if (collision.CompareTag("Enemy") && !isDead) // Change to the tag of your damaging objects
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        if (!isDead)
        {
            currentLives--; // Decrease lives when taking damage
            UpdateLivesUI(); // Update the UI to reflect remaining lives

            // Play the hit sound effect when the player takes damage
            if (audioSource != null && hitSFX != null)
            {
                audioSource.PlayOneShot(hitSFX);
            }

            if (currentLives <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        isDead = true; // Prevent triggering death multiple times

        // Play the death sound effect
        if (audioSource != null && deathSFX != null)
        {
            audioSource.PlayOneShot(deathSFX);
        }

        // Delay scene transition until death SFX finishes
        Invoke("LoadGameOverScene", deathSFX.length);
    }

    private void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOverScene"); // Replace with your Game Over scene name
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives; // Update lives text in the UI
        }
    }
}
