using UnityEngine;
using UnityEngine.UI; 

public class GuiManager : MonoBehaviour
{
    public Text livesText;  
    public Text scoreText;
    //public Text resultScoreText;

    private int currentScore;

    void Start()
    {
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
        currentScore = score;
    }

    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    //public void ShowResults()
    //{
    //    int highScore = PlayerPrefs.GetInt("HighScore", 0);
    //    resultScoreText.text = "Your Score: " + currentScore + "\nHigh Score: " + highScore;
    //}
}

