using UnityEngine;

public class HeartManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AddLive();
            gameObject.SetActive(false);
        }
    }

    public void AddLive()
    {
        GameManager.Instance.LiveManager.AddLives();
    }
}
