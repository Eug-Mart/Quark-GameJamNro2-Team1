
public class ScoreManager 
{
    private int scoreInitial = 1000;

    public void AddPoints()
    {
        scoreInitial += 10;
    }    

    public void SubtractPoints(int score) 
    {
        scoreInitial -= score;

        if (scoreInitial < 0)
        {
            scoreInitial = 0;
        }
    }

    public int GetScore()
    {
        return scoreInitial;
    }

    public void ResetScore()
    {
        scoreInitial = 1000;
    }
}
