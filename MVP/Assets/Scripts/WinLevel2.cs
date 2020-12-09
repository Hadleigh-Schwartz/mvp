using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class WinLevel2 : MonoBehaviour {
 
    void OnTriggerEnter2D(Collider2D other) {
    	Debug.Log("entered");
    	Debug.Log(other);
        
        Debug.Log("success");
        SceneManager.LoadScene("level2-cloud-finish");
        
    }
}