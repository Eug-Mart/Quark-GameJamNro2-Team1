public class LiveManager 
{
    private int lives  = 3;
    public void AddLives()
    {
        if (lives < 5)
        {
            lives++;
        }
    }

    public void SubtractLives()
    {
        lives--;

        if (lives < 0)
        {
            lives = 0;
        }
    }

    public int GetLives()
    {
        return lives;
    }

    public bool GameOver()
    {
        return lives <= 0;
    }

    public void ResetLives() {
        lives = 3;
    }

}
