using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public static GameData instance;
    public static GameData Instance {  get { return instance; } }

    public static int winStreak;
    public static int loseStreak;
    public static int matchCombo;
    public static int missCombo;
    public static float lastMatchT;

    public List<bool> archivementsLock = new List<bool>();

    public void Init()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
}
