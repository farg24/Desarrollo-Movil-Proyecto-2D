using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    public Text TextField;
    public Button a;

    public void  SetText(string text)
    {
        TextField.text = text;
    }

}
