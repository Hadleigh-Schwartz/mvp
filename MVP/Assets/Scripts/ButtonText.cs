using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    public Text textField;
    public string textStr;
    public void SetText(string txt)
    {
      textStr += txt;
    }
    public void ShowHideText()
    {
      if(textField.text != textStr)
      {
        textField.text = textStr;
      }
      else
      {
        textField.text = "";
      }
    }
}
