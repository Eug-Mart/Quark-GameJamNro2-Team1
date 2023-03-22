using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerGoal : MonoBehaviour
{
    public bool enableGoal;
    public bool random;
    public float speedGoal = 10f;
    public float minZGoal;
    public float maxZGoal;
    public float waitingTimeGoal = 2f;

    public GameObject archer;
    public bool enableArcher=false;
    public float speedArcher = 10f;
    public float longZArcher;

    private GameObject _targetGoal;
    private GameObject _targetArcher;
    private bool directionRightGoal=false;
    private bool directionRightArcher= false;
    private bool movingGoal = false;
    private bool movingArcher = false;
    private int stateMachineNumber = 0;

    
    void Update()
    {
        switch (stateMachineNumber)
        {
            case 2:
                stateMachineNumber = 0;
                break;

            case 1:
                if (enableArcher == true)
                {
                    if (movingArcher == false && movingGoal == false)
                    {
                        UpdateTargetArcher();
                        StartCoroutine("ArcherToTarget");
                    }
                }
                else stateMachineNumber = 0;
                break;

            case 0:
                if (enableGoal == true)
                {
                    if (movingGoal == false && movingArcher == false)
                    {
                        UpdateTargetGoal();
                        StartCoroutine("GoalToTarget");
                    }
                }
                else stateMachineNumber = 1;
                break;
        }
    }
    private void UpdateTargetGoal()
    {
        if (_targetGoal == null)
        {
            _targetGoal = new GameObject("TargetGoal");
        }  
        if (random == true)
        {
            float randomPosition = Random.Range(minZGoal,maxZGoal);
            _targetGoal.transform.position = new Vector3(transform.position.x, transform.position.y, randomPosition);
        }else
        if (directionRightGoal == false)
        {
            _targetGoal.transform.position = new Vector3(transform.position.x, transform.position.y, maxZGoal); // a la derecha
            directionRightGoal = true;
        }else 
        {
            _targetGoal.transform.position = new Vector3(transform.position.x, transform.position.y, minZGoal); // a la izquierda
            directionRightGoal = false;
        }

    }

    private void UpdateTargetArcher()
    {
        if (_targetArcher == null)
        {
            _targetArcher = new GameObject("TargetArcher");
        }
        if (directionRightArcher == false)
        {
            _targetArcher.transform.position = new Vector3(archer.transform.position.x, archer.transform.position.y, archer.transform.position.z + longZArcher);
            directionRightArcher = true;
        } else 
        {
            _targetArcher.transform.position = new Vector3(archer.transform.position.x, archer.transform.position.y, archer.transform.position.z - longZArcher);
            directionRightArcher = false;
        }
    }

    IEnumerator GoalToTarget()
    {
        movingGoal = true;
        while (Vector3.Distance(transform.position, _targetGoal.transform.position) > 0.05f)
        {
            Vector3 direction = _targetGoal.transform.position - transform.position;
            float zDirection = direction.z;
            transform.Translate(direction.normalized * speedGoal * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitingTimeGoal);
        movingGoal = false;
        stateMachineNumber += 1;
    }

    IEnumerator ArcherToTarget()
    {
        movingArcher = true;
        while (Vector3.Distance(archer.transform.position, _targetArcher.transform.position) > 0.05f)
        {
            Vector3 direction = _targetArcher.transform.position - archer.transform.position;
            float zDirection = direction.z;
            archer.transform.Translate(direction.normalized * speedArcher * Time.deltaTime);
            yield return null;
        }
        movingArcher = false;
        stateMachineNumber += 1;
    }
}
