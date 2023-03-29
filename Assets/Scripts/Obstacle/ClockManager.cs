using UnityEngine;

public class ClockManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddTimeToClock();
            gameObject.SetActive(false);
        }
    }

    //To-Do: agregar comportamiento
    public void AddTimeToClock()
    {
       
    }
}
