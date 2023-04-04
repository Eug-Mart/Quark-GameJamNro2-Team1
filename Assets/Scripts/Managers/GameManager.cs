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

    //public event Action OnPlayerTimeElapsed;
    //public event Action OnPlayerShooted;

    public GameObject mainCamera, stands, goal, obstacles;


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

    private void Start()
    {
        
    }

    private void Update()
    {
        if (!playerReachedGoalkeeper)
        {
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed >= difficulty * 10)
        {
            Debug.Log("entré");
            timeElapsed = 0f;
            playerReachedGoalkeeper = true;
            //OnPlayerTimeElapsed?.Invoke();
            mainCamera.GetComponent<Animator>().SetBool("cameraFadeIn", true);       
            goal.gameObject.SetActive(true);
        }
    }

    public void IncreaseDifficulty()
    {
        difficulty += 1;
        RestartShoot();
    }

    public void RestartShoot()
    {        
        playerReachedGoalkeeper = false;
        mainCamera.GetComponent<Animator>().SetBool("cameraFadeIn", false);
        goal.gameObject.SetActive(false);
        obstacles.gameObject.SetActive(true);
    }

}
