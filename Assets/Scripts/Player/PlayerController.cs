using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameOverManager gameOverManager;
    public ScoreEnterHandler scoreEnterHandler;
    private bool isDead = false;

    void Update()
    {
        if (GameOver() && !isDead)
        {
            isDead = true;
            gameOverManager.CallGameOver();
            scoreEnterHandler.AddScorePlayerToList();
        }

    }

    public bool GameOver()
    {
        return GameManager.Instance.LiveManager.GameOver();
    }
    
}
