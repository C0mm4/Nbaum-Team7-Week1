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
    public static int matchCombo;
    public static int missCombo;
    public static float lastMatchT;

    public static float titleTime = 0;

    public List<bool> archivementsLock = new List<bool>();

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
    }
}
