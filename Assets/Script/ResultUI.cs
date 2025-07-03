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
    [SerializeField]
    DescButton descButton;
    [SerializeField]
    ResultButton resultButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init()
    {
        descButton.OnClickDesc();
        descView.SetDescView(ResourceManager.Instance.GetRandomDescription());
        resultView.Init();
        // todo: resultView
    }


}
