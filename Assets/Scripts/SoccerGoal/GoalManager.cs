using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoalManager : MonoBehaviour
{
    [SerializeField] GameObject goalKeeper;
    private void Awake()
    {        
        
    }

    void Start()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnPlayerTimeElapsed += EnableGoalKeeper;
        }        
    }

    void Update()
    {

    }

    public void EnableGoalKeeper()
    {       
        goalKeeper.SetActive(true);       
    }
}
