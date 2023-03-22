
using UnityEngine;

namespace Assets.Scripts.Views.MainMenu.Interfaces
{
    public interface IMainMenuView
    {
        void InitializeTextValueToPlayButton();
        void InitializeTextValueToExitButton();
        void InitializeTextValueToScoresButton();
        void OnPlayButtonClicked();
        void OnExitButtonClicked();
        void OnScoresButtonClicked();
        void OnBackButtonClicked();

    }
}
