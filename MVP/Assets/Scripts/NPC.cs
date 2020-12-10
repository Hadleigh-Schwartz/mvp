using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour {

    public bool ShowInteractPrompt;
    public bool playerInRange;
    public bool usingNPC;
    public bool showDialogue;

    public GameObject interactPrompt;
    public GameObject dialoguePanel;
    public TextMeshProUGUI textDisplay;
    public GameObject continueButton;

    public string[] dialogue;
    private int index;
    public float typingSpeed = 0.02f;


    void Start()
    {
        interactPrompt.SetActive(false);

        continueButton.SetActive(false);
        dialoguePanel.SetActive(false);
        // NPCPosition = transform.position;

        StartCoroutine(Type());
    }
    void Update()
    {
        TalkToNPC();

        if(textDisplay.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }

        if(ShowInteractPrompt == true)
        {
            interactPrompt.SetActive(true);
        }
        else
        {
            interactPrompt.SetActive(false);
        }

    }
    void OnTriggerEnter2D(Collider2D anyCollider)
    {
        if(anyCollider.CompareTag("Player"))
        {
            ShowInteractPrompt = true;
            playerInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D anyCollider)
    {
        if(anyCollider.CompareTag("Player"))
        {
            ShowInteractPrompt = false;
            playerInRange = false;
        }
    }
    public void TalkToNPC()
    {
        //allow the player to press a button to talk to the NPC.
        if(playerInRange == true && Input.GetKeyDown(KeyCode.E) && ShowInteractPrompt == true)
        {
            ShowInteractPrompt = false;
            OpenDialogue();
            //SwitchCameras(firstPersonCamera, NPCCamera);
        }
        else if(usingNPC == true && playerInRange == false)
        {
            showDialogue = false;
            //SwitchCameras(NPCCamera, firstPersonCamera);
        }
    }
    public void OpenDialogue()
    {
        usingNPC = true;
        showDialogue = true;
        dialoguePanel.SetActive(true);
    }

    /*ACTUAL TYPING DIALOGUE
    /*ACTUAL TYPING DIALOGUE
    /*ACTUAL TYPING DIALOGUE
    /*ACTUAL TYPING DIALOGUE
    /*ACTUAL TYPING DIALOGUE*/
    IEnumerator Type()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    //when a player activates the dialogue, start the typing coroutine. Then, start it each time the player advances the dialogue

    public void NextDialogue()
    {
        continueButton.SetActive(false);
        if(index < dialogue.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            //deactivate canvas
            dialoguePanel.SetActive(false);
            index = 0;

            //if current scene is level 2, end of convo should trigger mini game
            Scene m_Scene = SceneManager.GetActiveScene();
            string sceneName = m_Scene.name;
            
            if(sceneName == "level2-cloud-intro"){
                SceneManager.LoadScene("level2-cloud");
            }
        }
    }
}
