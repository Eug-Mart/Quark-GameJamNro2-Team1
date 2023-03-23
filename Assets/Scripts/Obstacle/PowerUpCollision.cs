using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WeSubtractLifeAndPoints();
            gameObject.SetActive(false);
        }
    }

    public void WeSubtractLifeAndPoints()
    {
        GameManager.Instance.ScoreManager.SubtractPoints();
        GameManager.Instance.LiveManager.SubtractLives();
    }
}
