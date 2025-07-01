using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArchievementUI : MonoBehaviour
{
    public bool isArise;
    public Animator animator;
    public Text archivementName;
    public Text archivementDescription;

    public void Awake()
    {
    }

    public void SetNewArchivement()
    {
        animator.SetBool("isArise", true);
        isArise = true;

        Invoke("EndAriseAnimation", 1.5f);
    }

    public void EndAriseAnimation()
    {
        animator.SetBool("isArise", false);
        Invoke("EndFlag", 0.5f);
    }

    private void EndFlag()
    {
        isArise = false;
    }
}
