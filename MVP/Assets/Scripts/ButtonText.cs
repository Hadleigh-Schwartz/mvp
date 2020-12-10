using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    public Text textField;
    public string textStr;
    public GameObject acidPanel;
    public GameObject normalPanel;
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
    public void ShowHideAcidPanel(bool collected)
    {
      if(collected)
      {
        acidPanel.SetActive(!acidPanel.active);
      }
    }
    public void ShowHideNormalPanel(bool collected)
    {
      if(collected)
      {
        normalPanel.SetActive(!normalPanel.active);
      }
    }
    void Start()
    {
      acidPanel.SetActive(false);
      normalPanel.SetActive(false);
    }
}
