using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class EnterLake : MonoBehaviour {
 
    void OnTriggerEnter2D(Collider2D other) {
    	Debug.Log("entered");
    	Debug.Log(other);
        
        Debug.Log("success");
        if (other.gameObject.name == "Player")
      {
        SceneManager.LoadScene("level3");
      }
        
        
    }
}