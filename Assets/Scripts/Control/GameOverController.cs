using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private TMP_Text pointText;

    void Start()
    {
        Setup(ScoreManager.Score); 
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointText.text = score.ToString() + " POINTS";
    }

    public void TryAgain()
    {
        ScoreManager.ResetScore(); 
        SceneManager.LoadScene("GameScene"); 
    }
}
