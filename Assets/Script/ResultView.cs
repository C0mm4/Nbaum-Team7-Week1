using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class ResultView : MonoBehaviour
{
    List<Text> dataTexts = new List<Text>();
    public void Init()
    {
        if (dataTexts.Count == 0)
        {
            Text[] texts = GetComponentsInChildren<Text>();
            foreach (Text text in texts)
            {
                if (text.name.StartsWith("Data"))
                {
                    dataTexts.Add(text);
                }
            }
        }

        Debug.Log($"matchCombo : {GameData.matchCombo}, missCombo : {GameData.missCombo}");

        dataTexts[0].text = $"최대 콤보 횟수 : {GameData.maxCombo}";
        dataTexts[1].text = $"카드 뒤집은 횟수 : {GameData.flipCount}";
        dataTexts[2].text = $"이번 판 클리어 타임 : " + GameData.leftT.ToString("N2");

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

        float bestClearTime = 0f;
        if (PlayerPrefs.HasKey($"Time{GameManager.stageLevel}"))
        {
            bestClearTime = PlayerPrefs.GetFloat($"Time{GameManager.stageLevel}");
        }

        dataTexts[3].text = $"베스트 클리어 타임({level}) : " + bestClearTime.ToString("N2");

        float success_ratio = 0f;
        if (GameData.flipCount != 0)
        {
            success_ratio = ((float)((InGameManager.Instance.Card_size - InGameManager.Instance.leftCards) / 2) / (float)(GameData.flipCount / 2)) * 100f;
        }
        dataTexts[4].text = $"카드 매칭 성공률 : " + success_ratio.ToString("N2") + "%";
    }
}
