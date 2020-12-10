using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBehaviour : MonoBehaviour
{

    public level3behavior gameManager3;
    // Start is called before the first frame update
    void Start()
    {
    
        gameManager3 = GameObject.Find("GameManager").GetComponent<level3behavior>();
    }

    // Update is called once per frame
    void OnCollisionStay2D(Collision2D collision)
    {
      if (collision.gameObject.name == "Player")
      {
        Debug.LogFormat("plant collided with player");
        if(gameManager3.GetHealth() != 5)
        {
          Debug.LogFormat("destroy plant");
          gameManager3.plantsKilled ++;
          Destroy(this.gameObject);
        }
      }
    }
}
