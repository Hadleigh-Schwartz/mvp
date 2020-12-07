//Troubleshooting
//1. Make sure it's all Collider2D, not Collider
//2. Make sure this script is in an Empty as a child of the NPC, along with a collider2D that is marked "IsTrigger"
//3. Make sure the player's tag is "Player"

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private PlayerKinematic player;
    // public
        //Get NPC's position and make the dialogue box appear above his head. Rigidbody2D position?

    public bool showInteractButton;
    public bool playerInRange;
    public bool usingNPC;
    public bool showDialogue;

    public Camera firstPersonCamera;
    public Camera NPCCamera;
    public Transform _audioListener;

    void Start()
    {
        showInteractButton = false;
    }
    void Update()
    {
        //see if player has entered NPC area.
        TalkToNPC();
    }

    void OnTriggerEnter2D(Collider2D anyCollider)//But whose collider does this activate?? Whenever this object collides with ANY trigger
    {
        //check that nothing is blocking the player, nothing is btwn them and the NPC with a Raycast
            //playerInRange = true;
        //have a graphical thing pop up to indicate to player they can press a button
        if(anyCollider.CompareTag("Player"))
        {
            showInteractButton = true;
            playerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D anyCollider)
    {
        if(anyCollider.CompareTag("Player"))
        {
            showInteractButton = false;
            playerInRange = false;
        }
    }
    public void TalkToNPC()
    {
        //allow the player to press a button to talk to the NPC.
        if(playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            showInteractButton = false;
            OpenDialogue();
            //SwitchCameras(firstPersonCamera, NPCCamera);
        }
        if(usingNPC == true && playerInRange == false)
        {
            showDialogue = false;
            //SwitchCameras(NPCCamera, firstPersonCamera);
        }
    }
    public void OpenDialogue()
    {
        usingNPC = true;
        showDialogue = true;
        //disable walking?? How to
        //player.canMove = false;
    }
    //public void SwitchCameras(Camera fromCam, Camera toCam) //disable current camera and switch to another
    // {
    //     fromCam.enabled = false;
    //     toCam.enabled = true;
    //     _audioListener.parent = toCam.transform;
    //     _audioListener.localPosition = Vector3.zero;
    //     _audioListener.localRotation = Quaternion.identity;
    // }
    void OnGUI()
    {
        if(showInteractButton == true)
        {
            GUI.Box(new Rect(Screen.width/2-80, Screen.height/2-100, Screen.width/2-220, Screen.height/2-220), "Press E to talk to the NPC.");
        }
        if(showDialogue == true)
        {
            GUI.Box(new Rect(Screen.width/4-50, Screen.height/4-50, Screen.width/4-100, Screen.height/2-100), "Hello, I'm NPC");
            // if(Input.GetKeyDown(KeyCode.Escape))
            // {
            //     showDialogue = false;
            //     SwitchCameras(NPCCamera, firstPersonCamera);
            // }
        }
    }
    //if player has crafting menu open, pressing "esc" or their assigned key will close it.
}
