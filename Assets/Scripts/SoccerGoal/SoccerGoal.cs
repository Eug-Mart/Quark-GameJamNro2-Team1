using Assets.Scripts.SoccerGoal.Enum;
using System.Collections;
using System.Linq;
using UnityEngine;
using static Assets.Scripts.SoccerGoal.Enum.Enum;

public class SoccerGoal : MonoBehaviour
{

    Goal goal = new Goal();
    Archer archer = new Archer();
    private GameObject _targetGoal;
    public  GameObject gameObjectArcher;
    private GameObject _targetArcher;
    private int machineStatusNumber = (int)MachineStatusNumber.moveArc;

    void Update()
    {
        switch (machineStatusNumber)
        {
            case (int)MachineStatusNumber.restartStatus:
                setMachineStatusNumber(MachineStatusNumber.moveArc); 
                break;

            case (int)MachineStatusNumber.moveArcher:
                UpdateTargerAndStartCoroutineArcher();
                break;

            case (int)MachineStatusNumber.moveArc:
                UpdateTargerAndStartCoroutineGoal();
                break;
        }
    }

    private void UpdateTargerAndStartCoroutineGoal()
    {
        if (goal.IsGoalEnabled)
        {
            if (  !goal.IsMoving  && !archer.IsMoving  )
            {
                UpdateTargetGoal();
                StartCoroutine("MoveTowardsTargetOverTimeCoroutineGoal");
            }
        }
        else setMachineStatusNumber(MachineStatusNumber.moveArcher);
    }

    private void UpdateTargerAndStartCoroutineArcher()
    {
        if (archer.IsArcherEnabled)
        {
            if (!archer.IsMoving && !goal.IsMoving )
            {
                UpdateTargetArcher();
                StartCoroutine("MoveTowardsTargetOverTimeCoroutineArcher");
            }
        }
        else setMachineStatusNumber(MachineStatusNumber.moveArc);
    }

    private void setMachineStatusNumber(Enum.MachineStatusNumber newValue)
    {
        machineStatusNumber = (int)System.Enum.GetValues(typeof(MachineStatusNumber)).OfType<MachineStatusNumber>().Where( x => x == newValue).SingleOrDefault();
    }

    private void UpdateTargetGoal()
    {
        if (_targetGoal == null)
        {
            _targetGoal = new GameObject("TargetGoal");
        }  
        if (goal.IsRandomMovementEnable)
        {
            float randomPosition = Random.Range(goal.ZminValue,goal.ZmaxValue);
            _targetGoal.transform.position = new Vector3(transform.position.x, transform.position.y, randomPosition);
        }
    }

    private void UpdateTargetArcher()
    {
        if (_targetArcher == null)
        {
            _targetArcher = new GameObject("TargetArcher");
        }
        if (!archer.MovementStartsRight)
        {
            _targetArcher.transform.position = new Vector3(gameObjectArcher.transform.position.x, gameObjectArcher.transform.position.y, gameObjectArcher.transform.position.z + archer.ArcherkeeperZDistance);
            archer.setMovementStartsRight(true);
        } else 
        {
            _targetArcher.transform.position = new Vector3(gameObjectArcher.transform.position.x, gameObjectArcher.transform.position.y, gameObjectArcher.transform.position.z - archer.ArcherkeeperZDistance);
        }
    }
    
    IEnumerator MoveTowardsTargetOverTimeCoroutineGoal()
    {
        goal.setIsMoving(true);
        while (Vector3.Distance(transform.position, _targetGoal.transform.position) > 0.05f)
        {
            Vector3 direction = _targetGoal.transform.position - transform.position;
            transform.Translate(direction.normalized * goal.TargetSpeed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(goal.WaitingTime);
        goal.setIsMoving(false);
        setMachineStatusNumber(MachineStatusNumber.moveArcher);
    }

    IEnumerator MoveTowardsTargetOverTimeCoroutineArcher()
    {

        goal.setIsMoving(true);
        while (Vector3.Distance(gameObjectArcher.transform.position, _targetArcher.transform.position) > 0.05f)
        {
            Vector3 direction = _targetArcher.transform.position - gameObjectArcher.transform.position;
            gameObjectArcher.transform.Translate(direction.normalized * archer.TargetSpeed * Time.deltaTime);
            yield return null;
        }
        archer.setIsMoving(false);
        setMachineStatusNumber(MachineStatusNumber.moveArcher);
    }
    
}
