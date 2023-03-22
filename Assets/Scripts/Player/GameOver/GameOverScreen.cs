using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;

    public void Setup()
    {
        gameObject.SetActive(true);
        scoreText.text = $"{ GameManager.Instance.ScoreManager.GetScore() } POINTS";
    }

    public void OnRestartButtonClicked()
    {
        SceneManager.LoadScene("PlayerScene");
    }

    public void OnBackMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
