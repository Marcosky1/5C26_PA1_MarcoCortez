using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultsManager : MonoBehaviour
{
    public Text scoreText; 
    public Button backButton; 

    private void Start()
    {

        int finalScore = PlayerPrefs.GetInt("CurrentScore", 0);
        scoreText.text = "Puntaje Final: " + finalScore.ToString();

        backButton.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

