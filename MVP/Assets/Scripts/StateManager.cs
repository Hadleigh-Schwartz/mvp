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

    	 GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
 		myButtonStyle.fontSize = 30;
    	GUI.Box(new Rect(10,75,300,35), "Current state: "+ state, myButtonStyle);

    	// if(showErrorScreen == true){
    	// 	GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,330,100), "INCORRECT STATE CHANGE! Click here to continue");
    	// }

    	// if(GUI.Button(getRect(), content)){
     //        GameObject.Find("wilson2").animation.Play("carry");
     //        print("pressed");
 
     //    }
    	if(showErrorScreen == true){
    		if(state == "liquid"){
			    if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,360,100), "You must be a gas to condense! Click here to continue"))
			    {
			    	// yield return new WaitForSeconds(5);
			    	// showErrorSc
			        //Destroy(errorBox);
			        // Time.timeScale = 1.0f;
			        showErrorScreen = false;
			    }
		 	}

		 	if(state == "gas"){
			    if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2-50,360,100), "You must be a liquid to evaporate! Click here to continue"))
			    {
			    	// yield return new WaitForSeconds(5);
			    	// showErrorSc
			        //Destroy(errorBox);
			        // Time.timeScale = 1.0f;
			        showErrorScreen = false;
			    }
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
