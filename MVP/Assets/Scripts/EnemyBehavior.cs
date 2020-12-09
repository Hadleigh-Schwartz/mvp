using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{
   
   
    public Level2Behavior gameManager;

    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<Level2Behavior>();
      Debug.Log("hi");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
   
      Debug.Log("Hit: "+collision.gameObject.name);
     
      if (collision.gameObject.name == "Player")
      {
        gameManager.HP --;
      }
    }


}
