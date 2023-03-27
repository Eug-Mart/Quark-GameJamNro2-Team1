
public class ScoreManager 
{
    private int score = 1000;

    public void AddPoints()
    {
        score+=10;
    }    

    public void SubtractPoints() 
    {
        score-=10;

        if (score < 0)
        {
            score = 0;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 1000;
    }
}
