﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observation : Singleton<Observation>
{
    private List<string> wordList = new List<string>();
    private bool allCluesFound = false;

    public List<string> getCurrentWordList()
    {
        return wordList;
    }

    public bool AddWordToList(string wordBeingAdded)
    {
        if (!wordList.Contains(wordBeingAdded))
        {
            wordList.Add(wordBeingAdded);
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wordList.Count == 3 && !allCluesFound)
        {
            allCluesFound = true;
            FlowController.Instance.UpdateClueText();
        }
    }
}
