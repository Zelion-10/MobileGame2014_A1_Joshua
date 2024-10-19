using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

       
    [SerializeField]
    TextMeshProUGUI scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  public void ChangeScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    void UpdateScore()
    {
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
}
