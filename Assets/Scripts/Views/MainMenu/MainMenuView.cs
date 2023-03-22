using Assets.Scripts.Views.MainMenu.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour , IMainMenuView
{
    private MainMenuPresenter _presenter;
    public GameObject panelHighScoreTable;

    void Start()
    {
        _presenter = new MainMenuPresenter(this);
        this.InitializeTextValueOfAllMenuButtons();
    }

    #region Implements methods IMainMenuView
    public void OnPlayButtonClicked()
    {
        _presenter.OnPlayButtonClicked();
    }

    public void OnExitButtonClicked()
    {
        _presenter.OnExitButtonClicked();
    }

    public void OnScoresButtonClicked()
    {
        _presenter.OnScoresButtonClicked(this.panelHighScoreTable);
    }

    public void OnBackButtonClicked()
    {
        _presenter.OnBackButtonClicked(this.panelHighScoreTable);
    }

    public void InitializeTextValueOfAllMenuButtons()
    {
        InitializeTextValueToPlayButton();
        InitializeTextValueToScoresButton();
        InitializeTextValueToExitButton();
    }

    public void InitializeTextValueToPlayButton()
    {
        var button = GameObject.Find("ButtonPlay").GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = _presenter.GetNameButtonPlay();
    }
    public void InitializeTextValueToScoresButton()
    {
        var button = GameObject.Find("ButtonScores").GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = _presenter.GetNameButtonScores();
    }
    public void InitializeTextValueToExitButton()
    {
        var button = GameObject.Find("ButtonExit").GetComponent<Button>();
        button.GetComponentInChildren<Text>().text = _presenter.GetNameButtonExit();
    }


    #endregion


}
