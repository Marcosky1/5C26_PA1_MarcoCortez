using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void OnEnable() {
    }

    private void OnDisable() {
    }

    public void ManagePoints(CandyController candyInstance, PlayerManager playerInstance){
        playerInstance.score += candyInstance.points;
    }

    public void ManageLife(EnemyController enemyInstance, PlayerManager playerInstance){
        int lives = playerInstance.lives;

        lives = Mathf.Clamp(lives - enemyInstance.damage,0,5);
        
        playerInstance.lives = lives;
    }
}
