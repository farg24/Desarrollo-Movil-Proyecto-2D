using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManagerControl : MonoBehaviour
{
    [Header("UI Text Variables")]

    public Text textTouchPhase;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            textTouchPhase.text = "TOUCH";
        }

        else
            textTouchPhase.text = "NOTHING";
    }
}
