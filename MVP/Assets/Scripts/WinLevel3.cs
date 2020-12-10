using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLevel3 : MonoBehaviour
{
  public level3behavior gameManager2;
  void Start()
  {
    gameManager2 = GameObject.Find("GameManager").GetComponent<level3behavior>();
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
