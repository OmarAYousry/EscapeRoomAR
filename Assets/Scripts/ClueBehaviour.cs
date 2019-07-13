using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClueBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text targetText;
    public string TargetString { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        if (targetText == null)
        {
            targetText = GetComponentInChildren<Text>();
        }
        TargetString = targetText.text;

        //transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(TargetString);
    }
}
