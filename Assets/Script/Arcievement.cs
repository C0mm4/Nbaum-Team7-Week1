using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string id;
    public string title;
    public string description;
}

[System.Serializable]
public class AchievementList
{
    public List<Achievement> list;
}