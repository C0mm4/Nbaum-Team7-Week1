using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    [SerializeField]
    Text BestClearTimeText;
    List<Text> dataTexts = new List<Text>();
    public void Init()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            if (text.name.StartsWith("Data"))
            {
                dataTexts.Add(text);
            }
        }

        Debug.Log($"matchCombo : {GameData.matchCombo}, missCombo : {GameData.missCombo}");

        dataTexts[0].text = GameData.maxCombo.ToString();
        dataTexts[1].text = GameData.flipCount.ToString();
        dataTexts[2].text = GameData.leftT.ToString("N2");

        string level;
        switch (GameManager.stageLevel)
        {
            case 0:
                level = "Easy";
                break;
            case 1:
                level = "Normal";
                break;
            case 2:
                level = "Hard";
                break;
            case 3:
                level = "???";
                break;
            default:
                level = "";
                break;
        }

        BestClearTimeText.text = $"베스트 클리어 타임({level}) :";

        Debug.Log("Check High score");
        Debug.Log($"Time{GameManager.stageLevel}");
        if (PlayerPrefs.HasKey($"Time{GameManager.stageLevel}"))
        {
            float bestClearTime = PlayerPrefs.GetFloat($"Time{GameManager.stageLevel}");
            dataTexts[3].text = bestClearTime.ToString("N2");
        }
        else
        {
            Debug.Log("no high score");
            dataTexts[3].text = "00.00";
        }

        dataTexts[4].text = ((float)InGameManager.Instance.Card_size / (float)GameData.flipCount).ToString("N2");
    }
}
