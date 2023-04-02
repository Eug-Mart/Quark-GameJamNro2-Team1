﻿using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreValue;

    private void Update()
    {
        UpdateScoreValue();
    }
    public void UpdateScoreValue()
    {
        scoreValue.text = "Score " + GameManager.Instance.ScoreManager.GetScore().ToString();
    }
}
