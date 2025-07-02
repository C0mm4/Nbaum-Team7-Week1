using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Description 
{
    public string id;
    public string title;
    public string img;
    public string description;
    public string player;
}

[System.Serializable]
public class DescriptionList
{
    public List<Description> list;
}
