using Assets.Scripts.Views.MainMenu.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPresenter 
{
    private readonly IMainMenuView _view;
    private readonly MainMenuModel _model;

    public MainMenuPresenter(IMainMenuView view)
    {
        _view = view;
        _model = new MainMenuModel();
    }

    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("PlayerScene");
    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
    }

    public void OnScoresButtonClicked(GameObject panelBestScores)
    {
        panelBestScores.SetActive(true);
    }


    public void OnBackButtonClicked(GameObject panelBestScores)
    {
        panelBestScores.SetActive(false);
    }

    #region Methods that return text values for main menu buttons
    public string GetNameButtonPlay()
    {
        return _model.PlayButtonText;
    }
    public string GetNameButtonScores()
    {
        return _model.ScoresButtonText;
    }
    public string GetNameButtonExit()
    {
        return _model.ExitButtonText;
    }

    #endregion

}
