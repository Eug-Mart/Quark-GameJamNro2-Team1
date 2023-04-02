using UnityEngine;
using UnityEngine.UI;

public class Live : MonoBehaviour
{
    public Text liveValue;
    private void Update()
    {
        UpdateLiveeValue();
    }

    public void UpdateLiveeValue()
    {
        liveValue.text = "Lives " + GameManager.Instance.LiveManager.GetLives().ToString();
    }
}
