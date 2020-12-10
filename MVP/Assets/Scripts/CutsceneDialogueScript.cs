using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CutsceneDialogueScript : MonoBehaviour {

    public GameObject dialoguePanel;
    public TextMeshProUGUI textDisplay;
    public GameObject continueButton;

    public string[] dialogue;
    private int index;
    public float typingSpeed = 0.02f;


    void Start()
    {
        continueButton.SetActive(false);
        dialoguePanel.SetActive(true);

        StartCoroutine(Type());
    }
    void Update()
    {

        if(textDisplay.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }
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
            Destroy(gameObject);
        }
    }
}
