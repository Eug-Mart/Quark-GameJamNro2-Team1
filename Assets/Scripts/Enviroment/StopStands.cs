using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopStands : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.playerReachedGoalkeeper)
        {
            GetComponent<EndlessScroll>().enabled = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        else
        {
            GetComponent<EndlessScroll>().enabled = true;
        }
    }
}
