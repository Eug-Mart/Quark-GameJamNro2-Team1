﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WeIncrementLifeAndPoints();
            gameObject.SetActive(false);
        }
    }

    public void WeIncrementLifeAndPoints()
    {
        GameManager.Instance.ScoreManager.AddPoints();
        GameManager.Instance.LiveManager.AddLives();
    }
}
