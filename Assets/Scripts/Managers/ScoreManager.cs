using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int Score { get; set; } = 0; 

    public static void ResetScore()
    {
        Score = 0; // Reset the score to zero
    }
}
