using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public ScoreManager ScoreManager { get; private set; }
    public LiveManager LiveManager { get; private set; }

    public bool playerReachedGoalkeeper = false;
    public float timeElapsed = 0f;
    public int difficulty = 1;

    public bool PlayerReachedGoalkeeper { get; set; }    
    public int Difficulty { get; set; }

    public event Action OnPlayerTimeElapsed;

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

    private void Update()
    {
        if (!playerReachedGoalkeeper)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed >= difficulty * 10)
        {
            timeElapsed = 0f;
            playerReachedGoalkeeper = true;
            OnPlayerTimeElapsed?.Invoke();
        }
    }

}
