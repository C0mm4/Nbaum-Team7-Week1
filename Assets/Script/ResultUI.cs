using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    DescView descView;
    [SerializeField]
    ResultView resultView;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init()
    {
        descView.SetDescView(ResourceManager.Instance.GetRandomDescription());
        // todo: resultView
    }


}
