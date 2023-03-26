using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text scoreText;
    public void CallGameOver()
    {
        gameOverUI.SetActive(true);
        scoreText.text = $"{GameManager.Instance.ScoreManager.GetScore()} POINTS";
    }

    public void OnRestartButtonClicked()
    {
        CloseMenuGameOver();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnBackMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void CloseMenuGameOver()
    {
        gameOverUI.SetActive(false);
    }
}
