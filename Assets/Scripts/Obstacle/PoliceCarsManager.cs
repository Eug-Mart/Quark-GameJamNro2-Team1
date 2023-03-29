using UnityEngine;

public class PoliceCarsManager : MonoBehaviour
{
    private const int numberScoreToSubstract = 15;
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
        GameManager.Instance.ScoreManager.SubtractPoints(numberScoreToSubstract);
        GameManager.Instance.LiveManager.SubtractLives();
    }
}
