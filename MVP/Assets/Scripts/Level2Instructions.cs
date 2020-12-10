using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Instructions : MonoBehaviour
{
  
    public string labelText = "Go talk to the other water molecule!";

    void OnGUI()
    {
      GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
    myButtonStyle.fontSize = 25;
  

      GUIStyle guiStyle = new GUIStyle(); //create a new variable
      guiStyle.fontSize = 35;
      GUI.Label(new Rect(Screen.width/2 - 250, Screen.height - 50, 300, 50),
        labelText, guiStyle);



    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
