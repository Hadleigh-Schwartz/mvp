using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneDialogueMove : MonoBehaviour
{
    public PlayerKinematicClouds player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3 (0, 5, 0);
        transform.position = player.transform.position + offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
