using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLevel3 : MonoBehaviour
{
    public void StartChallenge()
    {
      SceneManager.LoadScene("level3");
    }
}
