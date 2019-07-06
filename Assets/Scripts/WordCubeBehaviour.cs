using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordCubeBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text targetText;
    private string targetString;
    // Start is called before the first frame update
    void Awake()
    {
        if (targetText == null)
        {
            targetText = GetComponentInChildren<Text>();
        }
        targetString = targetText.text;

        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(targetString);
    }
}
