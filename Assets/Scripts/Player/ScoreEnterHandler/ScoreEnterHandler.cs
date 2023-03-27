using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreEnterHandler : MonoBehaviour
{
    const string fileName = "DataSaveScores.js";
    List<PlayerSaveData> playerSaveDatas = new List<PlayerSaveData>();
    public static ScoreEnterHandler Instance = new ScoreEnterHandler();
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LoadScorePlayerToList();
    }

    public void AddScorePlayerToList()
    {
        if (ValidateGameOver()) {
            playerSaveDatas.Add(new PlayerSaveData(GameManager.Instance.ScoreManager.GetScore()));
            FileHandler.SaveToJSON(playerSaveDatas, fileName);
        }
    }

    public void LoadScorePlayerToList()
    {
        playerSaveDatas = FileHandler.ReadListFromJSON<PlayerSaveData>(fileName);
    }

    public List<PlayerSaveData> GetTopScores()
    {
        var listAllScores = FileHandler.ReadListFromJSON<PlayerSaveData>(fileName);
        return listAllScores.OrderByDescending( x=> x.Score).Take(10).ToList();
    }

    private bool ValidateGameOver()
    {
        return GameManager.Instance.LiveManager.GameOver();
    }

}
