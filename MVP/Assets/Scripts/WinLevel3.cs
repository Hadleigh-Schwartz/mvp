using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel3 : MonoBehaviour
{
  public Level2Behavior gameManager2;
  void Start()
  {
    gameManager2 = GameObject.Find("GameManager").GetComponent<Level2Behavior>();
  }
  void OnTriggerEnter2D(Collider2D other) {
    Debug.Log("entered");
    Debug.Log(other);

      Debug.Log("success");
      if (other.gameObject.name == "Player")
      {
        gameManager2.showWinScreen = true;
      }

  }
}
