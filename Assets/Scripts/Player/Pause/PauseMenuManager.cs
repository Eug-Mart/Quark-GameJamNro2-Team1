using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{

    [SerializeField] private GameObject buttomPause;
    [SerializeField] private GameObject menuPause;

    public void Pause()
    {
        Time.timeScale = 0f;
        buttomPause.SetActive(false);
        menuPause.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Continue()
    {
        buttomPause.SetActive(true);
        menuPause.SetActive(false);
    }

}
