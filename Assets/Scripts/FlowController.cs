using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowController : MonoBehaviour
{
    [SerializeField]
    private Canvas mainCanvas;
    [SerializeField]
    private List<string> introduction;
    private int introductionCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeIntroText", 5f);
    }

    private void ChangeIntroText()
    {
        mainCanvas.GetComponentInChildren<Text>().text = introduction[introductionCounter];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
