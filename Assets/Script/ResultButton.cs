using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButton : MonoBehaviour
{
    [SerializeField]
    GameObject descView;
    [SerializeField]
    GameObject resultView;
    
   
    public void OnClickResult()
    {

        descView.SetActive(false);
        resultView.SetActive(true);
    }
}
