
[System.Serializable]
public class PlayerSaveData
{
    #region Properties  
    public int Score { get; set; }
    public PlayerSaveData(int score) 
    { 
        Score = score;
    }
    #endregion
}
