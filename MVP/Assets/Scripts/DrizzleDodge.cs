using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrizzleDodge : MonoBehaviour {

    public GameObject[] waypoints;
    private int current = 0;
    public bool playerWasInRange = false;
    [SerializeField]
    float WPradius = .1f;

    void Update()
    {
        if(playerWasInRange == true)
        {
            MoveToWaypoint();
        }
    }

    void OnTriggerEnter2D(Collider2D anyCollider)
    {
        if(anyCollider.CompareTag("Player"))
        {
            playerWasInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D anyCollider)
    {
        if(anyCollider.CompareTag("Player"))
        {
            playerWasInRange = false;
        }
    }
    public void MoveToWaypoint()
    {
        if(Vector3.Distance(waypoints[current].transform.position, transform.position) > WPradius)
        {
            //current ++;
            if (current >= waypoints.Length)
            {
                //then level is done
                Debug.Log("Moved thru all waypoints");
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, 999f);
            //transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
            playerWasInRange = false;
        }
        else if(Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
        {
            current ++;
        }
    }
}

// when player hits the collider,
// activate the function that causes driz to move towards the waypoint.
// If driz is close enough to the waypoint,
// move to the next waypoint.
// After the final waypoint,
// driz "evaporates", goes off-screen, and player changes scene.

//problem: When driz moves, [OnTriggerEnter still thinks the player is in range]
