using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
  
    public AudioClip buttonClickSound; // Assign the audio clip for the button click in the Inspector
    private AudioSource audioSource;
    public float sceneSwitchDelay = 0.5f; // Delay in seconds before switching the scene

    private int score = 0;

    void Start()
    {
        // Get or add an AudioSource component to this GameObject
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        UpdateScore();
    }

    public void GameOver()
    {
       
    }

    public void ChangeScore(int amount)
    {
        score += amount;
        Debug.Log("Score changed: " + score);
        UpdateScore();
    }

    void UpdateScore()
    {
        if (scoreText == null)
        {
            Debug.LogError("scoreText is not assigned! Please assign a TextMeshProUGUI object in the Inspector.");
            return; // Exit the method if scoreText is not assigned
        }
        scoreText.text = "Score: " + score;
    }

    public void LoadGameScene()
    {
        PlayButtonSoundAndSwitchScene(1);
    }

    public void LoadInstructionScene()
    {
        PlayButtonSoundAndSwitchScene(2);
    }

    public void LoadMainMenu()
    {
        PlayButtonSoundAndSwitchScene(0);
    }

    public void Quit()
    {
        PlayButtonSoundAndQuit();
    }

    // Method to play button sound and switch scene
    public void PlayButtonSoundAndSwitchScene(int sceneIndex)
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Play the button click sound
            StartCoroutine(WaitAndSwitchScene(sceneIndex)); // Start coroutine to wait and switch scene
        }
        else
        {
            SceneManager.LoadScene(sceneIndex); // If no sound, switch scene immediately
        }
    }

    // Coroutine to wait before switching the scene
    private IEnumerator WaitAndSwitchScene(int sceneIndex)
    {
        yield return new WaitForSeconds(sceneSwitchDelay); // Wait for the delay
        SceneManager.LoadScene(sceneIndex); // Switch to the specified scene
    }

    // Method to play button sound and quit the application
    public void PlayButtonSoundAndQuit()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Play the button click sound
            StartCoroutine(WaitAndQuit()); // Start coroutine to wait and quit
        }
        else
        {
            QuitImmediately(); // If no sound, quit immediately
        }
    }

    // Coroutine to wait before quitting the application
    private IEnumerator WaitAndQuit()
    {
        yield return new WaitForSeconds(sceneSwitchDelay); // Wait for the delay
        QuitImmediately();
    }

    // Quit application
    private void QuitImmediately()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
