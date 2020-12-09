using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    public Text textField;
    public void SetText(string txt)
    {
      if(textField.text == "")
      {
        textField.text = txt;
      }
      else
      {
        textField.text = "";
      }
    }
}
