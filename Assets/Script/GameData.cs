using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static GameData instance;
    public static GameData Instance {  get { return instance; } }

    public static int winStreak;
    public static int loseStreak;
    public static bool isFirstrun;
    public static int matchCombo; // ī�� ��Ī �޺���
    public static int maxCombo; // �ְ� �޺� Ƚ��
    public static int flipCount; // ������ Ƚ��
    public static int missCombo; // ī�� ��Ī ���� �޺� Ƚ��
    public static float lastMatchT;


    public static float leftT; // Ŭ���� �� ���� �ð�

    public static float titleTime = 0;

    public static int clearCnt;
    public static int hiddenClearCnt;

    public int titleClickCnt = 0;
    public void Init()
    {
        if(instance == null)
        {
            instance = this;
        }
        if (!PlayerPrefs.HasKey("isFirstRun"))
        {
            isFirstrun = true;
        }
        else
        {
            isFirstrun = false;
        }
        if (!PlayerPrefs.HasKey("ClearCnt"))
        {
            clearCnt = 0;
        }
        else
        {
            clearCnt = PlayerPrefs.GetInt("ClearCnt");
        }
        if (!PlayerPrefs.HasKey("hiddenClearCnt"))
        {
            hiddenClearCnt = 0;
        }
        else
        {
            hiddenClearCnt = PlayerPrefs.GetInt("hiddenClearCnt");
        }
    }

    public static void startGame()
    {
        matchCombo = 0;
        maxCombo = 0;
        flipCount = 0;
        missCombo = 0;
        leftT = 60f;
        lastMatchT = Time.time;
    }
}
