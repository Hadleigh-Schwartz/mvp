using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior3 : MonoBehaviour
{
   
   
    public level3behavior gameManager;

    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<level3behavior>();
      Debug.Log("hi");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
   
      Debug.Log("Hit: "+collision.gameObject.name);
     
      if (collision.gameObject.name == "Player")
      {
        Debug.Log("was player");
        gameManager.HP --;
      }
    }


}
