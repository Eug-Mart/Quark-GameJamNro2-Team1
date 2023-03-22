using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    void Update()
    {
        if (GameOver())
        {
            gameOverScreen.Setup();
        }
    }

    public bool GameOver()
    {
        return GameManager.Instance.LiveManager.GameOver();
    }
    
}
