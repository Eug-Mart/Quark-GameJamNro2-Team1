using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ScoreManager ScoreManager { get; private set; }
    public LiveManager LiveManager { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        ScoreManager = new ScoreManager();
        LiveManager = new LiveManager();
    }

}
