using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
  
    public AudioClip buttonClickSound; 
    private AudioSource audioSource;
    public float sceneSwitchDelay = 0.5f; // Delay in seconds before switching the scene

    private int score = 0;

    void Start()
    {
        
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        UpdateScore();
    }

    public void GameOver()
    {
        ScoreManager.Score = score;
    }

    public void ChangeScore(int amount)
    {
        ScoreManager.Score += amount; // Update score in ScoreManager
        Debug.Log("Score changed: " + ScoreManager.Score);
        UpdateScore();
    }
    void UpdateScore()
    {
        if (scoreText == null)
        {
            Debug.LogError("scoreText is not assigned! Please assign a TextMeshProUGUI object in the Inspector.");
            return; // Exit the method if scoreText is not assigned
        }
        scoreText.text = "Score: " + ScoreManager.Score;
    }
    public void OnPlayerDeath()
    {
        GameOver(); 
                    
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
            audioSource.PlayOneShot(buttonClickSound); 
            StartCoroutine(WaitAndSwitchScene(sceneIndex)); 
        }
        else
        {
            SceneManager.LoadScene(sceneIndex); 
        }
    }

    // Coroutine to wait before switching the scene
    private IEnumerator WaitAndSwitchScene(int sceneIndex)
    {
        yield return new WaitForSeconds(sceneSwitchDelay); 
        SceneManager.LoadScene(sceneIndex); 
    }

    // Method to play button sound and quit the application
    public void PlayButtonSoundAndQuit()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); 
            StartCoroutine(WaitAndQuit()); 
        }
        else
        {
            QuitImmediately(); 
        }
    }

    // Coroutine to wait before quitting the application
    private IEnumerator WaitAndQuit()
    {
        yield return new WaitForSeconds(sceneSwitchDelay); 
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
