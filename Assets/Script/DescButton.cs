using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescButton : MonoBehaviour
{
    [SerializeField]
    GameObject descView;
    [SerializeField]
    GameObject resultView;

    private void Awake()
    {

    }

    public void OnClickDesc()
    {
        resultView.SetActive(false);
        descView.SetActive(true);
        OnButtonSelected();
    }

    private void OnButtonSelected()
    {
        GetComponent<Button>().image.color = Color.white;
        
        foreach (Transform tf in transform.parent)
        {
            Button other = tf.GetComponent<Button>();

            if (other && tf != transform)
            {
                other.image.color = Color.gray;
                other.transform.localScale = Vector3.one;

            }
        }

        transform.localScale = new Vector3(1.0f, 1.3f, 1.0f);
    }
}
