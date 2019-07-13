using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumKeyBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text targetText;
    public string TargetNum{ get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (targetText == null)
        {
            targetText = GetComponentInChildren<Text>();
        }
        TargetNum = targetText.text;

        //transform.GetChild(0).gameObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
