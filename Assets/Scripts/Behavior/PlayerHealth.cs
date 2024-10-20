using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxLives = 3; 
    private int currentLives; 

    [SerializeField]
    private AudioClip hitSFX;  
    [SerializeField]
    private AudioClip deathSFX; 
    private AudioSource audioSource; 

    [SerializeField]
    private TMP_Text livesText; 

    private bool isDead = false; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentLives = maxLives;
        UpdateLivesUI(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collision with damaging objects (e.g., enemies, hazards)
        if (collision.CompareTag("Enemy") && !isDead) 
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        if (!isDead)
        {
            currentLives--; 
            UpdateLivesUI(); 

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
        isDead = true; 

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
        SceneManager.LoadScene("GameOverScene"); 
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Health: " + currentLives; 
        }
    }
}
