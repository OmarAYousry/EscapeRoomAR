using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TouchController : MonoBehaviour
{
    void Update()
    {
        Vector2 touchPosition = new Vector2(-1f, -1f);
        float touchRadius = 0f;
        float touchRadiusVariance = 0f;
        if (Application.platform == RuntimePlatform.WindowsEditor)
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
            }
            else
            {
                Debug.Log("No targets hit :(");
            }
        }
    }
}
