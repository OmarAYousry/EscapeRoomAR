using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowController : Singleton<FlowController>
{
    [SerializeField]
    private Canvas mainCanvas;
    [SerializeField]
    private GameObject numberScreen;
    [SerializeField]
    private char[] numberSolution = { '0', '7', '1', '8' };
    private int numberSolutionIndex = 0;
    [SerializeField]
    private GameObject numberClue;
    [SerializeField]
    private string puzzleSolution;
    [SerializeField]
    private List<string> introduction;
    private int introductionCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("UpdateClueText", 5f);
        numberClue.GetComponentInChildren<Text>().text = "";
        for (int i = 0; i < numberSolution.Length; i++)
        {
            numberClue.GetComponentInChildren<Text>().text += numberSolution[i];
            numberClue.GetComponentInChildren<Text>().text += (i < numberSolution.Length - 1) ? " " : "";
        }
    }

    public void UpdateClueText()
    {
        if (introductionCounter < introduction.Count)
            mainCanvas.GetComponentInChildren<Text>().text = introduction[introductionCounter++];
    }

    public bool AttemptPuzzleSolution(string attempt)
    {
        if (attempt == puzzleSolution)
        {
            UpdateClueText();
            numberClue.SetActive(true);
            return true;
        }
        else
        {
            Debug.Log($"User attempt wrong puzzle: {attempt} while solution is {puzzleSolution}");
            Debug.Log(attempt == puzzleSolution);
            return false;
        }
    }

    public void AttemptNumberPad(char digit)
    {
        if (digit == numberSolution[numberSolutionIndex])
        {
            numberScreen.GetComponentInChildren<Text>().text += numberSolution[numberSolutionIndex++];
        }
        if (numberSolutionIndex == numberSolution.Length)
        {
            mainCanvas.GetComponentInChildren<Text>().text = "YOU WIN! GET OUT!";
        }
    }
}
