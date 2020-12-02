using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehavior : MonoBehaviour
{
    private int health = 2;
    public int Health
    {
      get {return health;}
      private set
      {
          health = value;
          if(IsDead())
          {
            Kill();
          }
      }
    }

    public Level2Behavior gameManager;

    void Start()
    {
      gameManager = GameObject.Find("GameManager").GetComponent<Level2Behavior>();
      Debug.Log("hi");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("hi2");
      Debug.Log("Hit: "+collision.gameObject.name);
      if(collision.gameObject.name == "Blast(Clone)")
      {
        Health -= 1;
        Debug.Log("Hit");
      }
      if (collision.gameObject.name == "aqua")
      {
        gameManager.HP --;
      }
    }

    //damage by input... returns 0 if dead, 1 if alive
    public uint Damage(int damage)
    {
      if(damage >=health)
      {
        health = 0;
        return 0;
      }
      else
      {
        health = health - damage;
        return 1;
      }
    }
    //function that returns if item is dead
    public bool IsDead()
    {
      if(health <= 0)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    //function that makes object dissapear
    void Kill()
    {
      Destroy(this.transform.gameObject);
      Debug.Log("Killed!");
      Debug.Log(this.transform.gameObject.name);
    }


    /*
    void OnCollisionEnter(Collision collision)
    {
       blast = collision.gameObject.GetComponent("HingeJoint") as Blast;
       if (collision.gameObject.name == "Blast")
       {
            Damage(1);
            if(IsDead())
            {
              Kill();
            }
       }
       if (collision.gameObject.name == "Marble")
       {
         gameManager.HP --;
       }
    }
    */
}
