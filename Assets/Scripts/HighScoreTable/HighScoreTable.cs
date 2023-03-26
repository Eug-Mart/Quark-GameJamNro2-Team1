using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.HighScoreTable.Enum.Enum;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private void Awake()
    {
        entryContainer = transform.Find("Elements");
        entryTemplate = entryContainer.Find("HighScoreElement");
        entryTemplate.gameObject.SetActive(false);
        CreateHighScoreEntry(GetTopScores(), entryContainer);
    }
    private void CreateHighScoreEntry(List<PlayerSaveData> highScoreEntry , Transform entryContainer)
    {
        float templateHeight = -30f;
        int position = 0;
        foreach (var score in highScoreEntry)
        {
            position++;
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, templateHeight * position);
            entryTransform.gameObject.SetActive(true);

            entryTransform.Find("Position").GetComponent<Text>().text = AddAbbreviations(position);
            entryTransform.Find("Score").GetComponent<Text>().text = score.Score.ToString();

        }
    }

    #region Private methods aux
    private string AddAbbreviations(int score)
    {
        Abbreviations abbreviations = Abbreviations.TH;
        switch (score)
        {
            case 1:
                abbreviations = Abbreviations.ST;
                break;
            case 2:
                abbreviations = Abbreviations.ND;
                break;
            case 3:
                abbreviations = Abbreviations.RD;
                break;
            default:
                abbreviations = Abbreviations.TH;
                break;
        }
        return abbreviations.ToString();
    }
    private List<PlayerSaveData> GetTopScores()
    {
        return ScoreEnterHandler.Instance.GetTopScores();
    }
    #endregion

}
