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
    public static int matchCombo; // Ä«µå ¸ÅÄª ÄÞº¸¼ö
    public static int maxCombo; // ÃÖ°í ÄÞº¸ È½¼ö
    public static int flipCount; // µÚÁýÀº È½¼ö
    public static int missCombo; // Ä«µå ¸ÅÄª ½ÇÆÐ ÄÞº¸ È½¼ö
    public static float lastMatchT;


    public static float leftT; // Å¬¸®¾î ½Ã ³²Àº ½Ã°£

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
