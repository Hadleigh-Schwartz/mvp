using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level3behavior : MonoBehaviour
{
    private uint _plantsKilled = 0;
    public bool showWinScreen = false;
    public bool showLoseScreen = false;
    public uint plantsKilled
    {
      get { return _plantsKilled; }
      set
      {
        _plantsKilled = value;
        if(_plantsKilled > 5)
        {
          showLoseScreen  = true;
          Time.timeScale = 0f;
        }
      }
    }

    void OnGUI()
    {

      if(showWinScreen)
      {
        if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,200,100), "YOU WON!"))
        {

        }
      }
      if(showLoseScreen)
      {
        if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,200,100), "KILLED PLANTS! TRY AGAIN"))
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
          Time.timeScale = 1.0f;
        }
      }
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
