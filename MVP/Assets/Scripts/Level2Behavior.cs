using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Behavior : MonoBehaviour
{
    private uint _aquaHealth = 3;
    private uint _goalsCollected = 0;
    public string labelText = "Collect the cyllinders and avoid the cubes!";
    public int maxGoals = 4;
    public bool showWinScreen = false;
    public bool showLoseScreen = false;

    public uint GoalsCollected
    {
      get { return _goalsCollected; }
      set
      {
        _goalsCollected = value;
        if(_goalsCollected >= maxGoals)
        {
          labelText = "Congrats! You collected all the goals";
          showWinScreen = true;
          Time.timeScale = 0f;
        }
        else
        {
          labelText = "Goal found, only "+(maxGoals-_goalsCollected)+" more to go!";
        }
        Debug.LogFormat("Goals: {0}", _goalsCollected);
      }
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
    
    void OnGUI()
    {
      GUI.Box(new Rect(20,20,150,25), "Player Health: "+_aquaHealth);
      GUI.Box(new Rect(20,50,150,25), "Goals Collected: "+_goalsCollected);
      GUI.Label(new Rect(Screen.width/2 - 100, Screen.height - 50, 300, 50),
        labelText);
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
