using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEnterHandler : MonoBehaviour
{
    [SerializeField] string fileName;
    List<PlayerSaveData> playerSaveDatas = new List<PlayerSaveData>();

    private void Start()
    {
        playerSaveDatas = FileHandler.ReadListFromJSON<PlayerSaveData>(fileName);
    }

    public void AddScorePlayerToList()
    {
        if (ValidateGameOver()) {
            playerSaveDatas.Add(new PlayerSaveData(GameManager.Instance.ScoreManager.GetScore()));
            FileHandler.SaveToJSON<PlayerSaveData>(playerSaveDatas, fileName);
        }
    }

    private bool ValidateGameOver()
    {
        return GameManager.Instance.LiveManager.GameOver();
    }

}
