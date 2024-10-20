using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

       
    [SerializeField]
    private TextMeshProUGUI scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    public void GameOver()
    {
        Debug.Log("Game Over called");
        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save(); // Ensure it's saved
        SceneManager.LoadScene("GameOverScene"); // Load Game Over scene
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
        SceneManager.LoadScene(1);
        

    }

    public void LoadInstructionScene()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
