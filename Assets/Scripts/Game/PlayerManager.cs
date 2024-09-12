using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int lives = 3;
    public int score = 0;
    public GuiManager guiManager;
    public ObjectPool objectPool;
    [SerializeField] private float distance = 0f;

    void Start()
    {
        UpdateGui();
    }

    private void Update() {
        distance += Time.deltaTime;

        if(distance >= 1){
            score += (int) distance;
            distance = 0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            HandleCollisionWithEnemy(other.gameObject);
        }
        else if (other.CompareTag("Candy"))
        {
            HandleCollisionWithCandy(other.gameObject);
        }
    }

    private void HandleCollisionWithEnemy(GameObject enemy)
    {
        lives--;
        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            UpdateGui();
        }

        DeactivateAndReturnToPool(enemy);
    }

    private void HandleCollisionWithCandy(GameObject candy)
    {
        AddScore(10);
        DeactivateAndReturnToPool(candy);
    }

    private void DeactivateAndReturnToPool(GameObject obj)
    {
        obj.SetActive(false); 
        objectPool.ReturnObject(obj); 
    }

    private void GameOver()
    {
        PlayerPrefs.SetInt("CurrentScore", score); 
        guiManager.SaveScore(score); 
        SceneManager.LoadScene("GameOver"); 
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateGui();
    }

    private void UpdateGui()
    {
        guiManager.UpdateLives(lives);
        guiManager.UpdateScore(score);
    }
}
