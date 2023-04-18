using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code partially from https://youtu.be/_nRzoTzeyxU

public class DialogueTrigger : MonoBehaviour
{
    public string dialogueName;
    public TextAsset JSONScript;

    public DialogueList dialogueList = new DialogueList();
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        // Find the dialogue from the JSON
        dialogueList = JsonUtility.FromJson<DialogueList>(JSONScript.text);

        foreach (Dialogue dialogueText in dialogueList.dialogue)
        {
            if(dialogueText.title == dialogueName)
            {
                dialogue = dialogueText;
            }
        }

        // Find the DialogueManager
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

        // If found, start dialogue
        if (dialogueManager)
        {
            dialogueManager.StartDialogue(dialogue);
        }
    }
}
