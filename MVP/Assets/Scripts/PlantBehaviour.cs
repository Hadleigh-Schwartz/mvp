using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{
    public Level2Behavior gameManager2;
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager2 = GameObject.Find("GameManager").GetComponent<Level2Behavior>();
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collision)
    {
      if (collision.gameObject.name == "Player")
      {
        Debug.LogFormat("plant collided with player");
        if(gameManager2.GetHealth() != 5)
        {
          Debug.LogFormat("destroy plant");
          Destroy(this.gameObject);
        }
      }
    }
}
