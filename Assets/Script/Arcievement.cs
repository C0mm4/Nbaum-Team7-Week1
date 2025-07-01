using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Archievement
{
    public string id;
    public string title;
    public string description;
}

[System.Serializable]
public class ArchievementList
{
    public List<Archievement> list;
}