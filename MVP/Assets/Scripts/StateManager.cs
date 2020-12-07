using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
	public string state = "liquid";

    public bool showErrorScreen = false;
    public bool displayMessage = false; 
    public float displayTime = 4f; 


    public void OnGUI()
    {

    	// if(showErrorScreen == true){
    	// 	GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,330,100), "INCORRECT STATE CHANGE! Click here to continue");
    	// }

    	// if(GUI.Button(getRect(), content)){
     //        GameObject.Find("wilson2").animation.Play("carry");
     //        print("pressed");
 
     //    }
    if(showErrorScreen == true){
	    if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,200,100), "YOU WON!"))
	    {
	        Destroy(this);
	        // Time.timeScale = 1.0f;
	    }
	 }
	  
    
      

      
      // if(showWinScreen)
      // {
      //   if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,200,100), "YOU WON!"))
      //   {
      //       SceneManager.LoadScene(0);
      //       Time.timeScale = 1.0f;
      //   }
      // }
      // if(showErrorScreen)
      // {
      //   if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,200,100), "YOU DIED! GAME OVER"))
      //   {
      //     SceneManager.LoadScene(0);
      //     Time.timeScale = 1.0f;
      //   }
      // }

      // if(showErrorScreen)
      // {
     	// GUI.Box(new Rect(Screen.width/2 -100, Screen.height/2-50,200,40), "INCORRECT STATE CHANGE"); 
      // }

     }

    // public void Message(float startTime){
    // 	displayMessage = true;
    // 	if (displayMessage) {
    //     if ((Time.time - startTime) < displayTime) {
    //         GUI.Label (new Rect (Screen.width/2,Screen.height/2,120,50), "Message goes here");
    //     } else {
    //         displayMessage = false;
    //     }
    // 	}
    // }


     
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
