using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Behavior : MonoBehaviour
{
    private uint _aquaHealth = 5;

    public string labelText = "Avoid the SO2 molecules and get to the finish line!";

    public bool showWinScreen = false;
    public bool showLoseScreen = false;


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
    
    void OnGUI()
    {
      GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
    myButtonStyle.fontSize = 30;
      GUI.Box(new Rect(10,100,300,30), "Player Health: "+_aquaHealth, myButtonStyle);
      // GUI.Box(new Rect(20,50,150,25), "Goals Collected: "+_goalsCollected);

      GUIStyle guiStyle = new GUIStyle(); //create a new variable
      guiStyle.fontSize = 35;
      GUI.Label(new Rect(Screen.width/2 - 100, Screen.height - 100, 300, 50),
        labelText, guiStyle);


      if(showWinScreen)
      {
        if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,200,100), "YOU WON!"))
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1.0f;
        }
      }
      if(showLoseScreen)
      {
        if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,200,100), "YOU DIED! GAME OVER"))
        {
          SceneManager.LoadScene(0);
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
