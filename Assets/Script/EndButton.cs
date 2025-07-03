using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    public void OnClickEnd()
    {
        GameManager.Instance.GoToTitle();
    }
}
