using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TouchController : MonoBehaviour
{
    private GameObject target;
    void Update()
    {
        Vector2 touchPosition = new Vector2(-1f, -1f);
        float touchRadius = 0f;
        float touchRadiusVariance = 0f;
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
            if (Input.GetMouseButton(0))
            {
                Debug.Log("MOUSE CLICK DETECTED!");
                touchPosition = Input.mousePosition;
            }
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                Debug.Log("TOUCH DETECTED!");
                touchPosition = Input.GetTouch(0).position;
                touchRadius = Input.GetTouch(0).radius;
                touchRadiusVariance = Input.GetTouch(0).radiusVariance;
                // TouchPhase.Moved // This might be good for only changing when the touch is moving
            }
        }
        if (touchPosition.x >= 0f)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(touchPosition), out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.collider.gameObject.name);
                if (hitInfo.collider.gameObject.CompareTag("Clue"))
                {
                    hitInfo.collider.transform.GetChild(0).gameObject.SetActive(true);
                    target = hitInfo.collider.gameObject;
                    if (target.GetComponent<ClueBehaviour>() != null)
                    {
                        Observation.Instance.AddWordToList(target.GetComponent<ClueBehaviour>().TargetString);
                    }
                }
                else if (hitInfo.collider.gameObject.CompareTag("Puzzle"))
                {
                    target = hitInfo.collider.gameObject;
                    if (target.GetComponent<PuzzleBehaviour>() != null)
                    {
                        FlowController.Instance.AttemptPuzzleSolution(target.GetComponent<PuzzleBehaviour>().TargetString);
                    }
                }
                else if (hitInfo.collider.gameObject.CompareTag("NumKey"))
                {
                    target = hitInfo.collider.gameObject;
                    if (target.GetComponent<NumKeyBehaviour>() != null)
                    {
                        FlowController.Instance.AttemptNumberPad(target.GetComponent<NumKeyBehaviour>().TargetNum.ToString()[0]);
                    }
                }
                else if (target != null)
                {
                    if (target.CompareTag("Clue"))
                    {
                        target.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    target = null;
                }
            }
            else
            {
                if (target != null)
                {
                    if (target.CompareTag("Clue"))
                    {
                        target.transform.GetChild(0).gameObject.SetActive(false);
                    }
                    target = null;
                }
                Debug.Log("No targets hit :(");
            }
        }
        else
        {
            if (target != null)
            {
                if (target.CompareTag("Clue"))
                {
                    target.transform.GetChild(0).gameObject.SetActive(false);
                }
                target = null;
            }
        }
    }
}
