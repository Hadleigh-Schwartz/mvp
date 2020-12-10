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
        if(_plantsKilled > 4)
        {
          showLoseScreen  = true;
          Time.timeScale = 0f;
        }
      }
    }

    private uint _aquaHealth = 3;


    public uint GetHealth()
    {
      return _aquaHealth;
    }
    public uint HP
    {
      get { return _aquaHealth; }
      set
      {
        _aquaHealth = value;
        Debug.LogFormat("HP: {0}", _aquaHealth);
        if(_aquaHealth == 0)
        {
          showLoseScreen  = true;
          Time.timeScale = 0f;
        }
      }
    }

    //damage by input... returns 0 if dead, 1 if alive
    public uint Damage(uint damage)
    {
      if(damage >=_aquaHealth)
      {
        _aquaHealth = 0;
        return 0;
      }
      else
      {
        _aquaHealth = _aquaHealth - damage;
        return 1;
      }
    }
    //function that returns if item is dead
    public bool IsDead()
    {
      if(_aquaHealth == 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public string labelText = "Avoid the SO2 and get to the finish line! Don't touch the plants!";

    void OnGUI()
    {

       GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
    myButtonStyle.fontSize = 30;
      GUI.Box(new Rect(10,100,300,30), "Player Health: "+_aquaHealth, myButtonStyle);
      

       GUIStyle guiStyle = new GUIStyle(); //create a new variable
       guiStyle.fontSize = 20;
       GUI.Label(new Rect(Screen.width/2 - 375, Screen.height - 35, 300, 50),
        labelText, guiStyle);

      if(showWinScreen)
      {
        if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,200,100), "YOU WON!"))
        {
          SceneManager.LoadScene("Home");
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
