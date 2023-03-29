using UnityEngine;

public class WheelsManager : MonoBehaviour
{
    private const int numberScoreToSubstract = 5;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WeSubtractPoints();
            gameObject.SetActive(false);
        }
    }

    public void WeSubtractPoints()
    {
        GameManager.Instance.ScoreManager.SubtractPoints(numberScoreToSubstract);
    }
}
