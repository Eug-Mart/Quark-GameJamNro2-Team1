﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameArea"))
        {
            Debug.Log("Largo de GameArea" + Vector3.right * (other.bounds.size.x + GetComponent<BoxCollider>().size.x));
            //transform.position -= Vector3.right * (other.bounds.size.x + GetComponent<BoxCollider>().size.x);   
        }
    }

}
