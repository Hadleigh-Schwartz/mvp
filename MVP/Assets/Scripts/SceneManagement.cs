using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneManagement : MonoBehaviour {

    public void startLevel2() {
    	Debug.Log("entered start level2");
        SceneManager.LoadScene("level2-cloud-intro");
        SceneManager.UnloadSceneAsync("Home");

    }

    public void returnHome() {
        SceneManager.LoadScene("Home");
        SceneManager.UnloadSceneAsync("level2-cloud-intro");

    }
}
