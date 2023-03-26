using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text scoreText;
    void Start()
    {
        gameOverUI.SetActive(false);
    }
    public void CallGameOver()
    {
        gameOverUI.SetActive(true);
        scoreText.text = $"{GameManager.Instance.ScoreManager.GetScore()} POINTS";
    }
    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex , LoadSceneMode.Single);
        GameManager.Instance.ScoreManager.ResetScore();
        GameManager.Instance.LiveManager.ResetLives();
        PlayerController.isDead = false;

    }
    public void OnBackMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
