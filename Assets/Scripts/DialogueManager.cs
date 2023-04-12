using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Code from https://youtu.be/_nRzoTzeyxU

public class DialogueManager : MonoBehaviour
{
    // UI Text
    public TMP_Text nameText;
    public TMP_Text dialogueText;

    // Queues for the names and lines of text
    private Queue<string> lines;
    private Queue<string> names;
    public GameObject dialoguePanel;

    void Start()
    {
        // Make sure menu is closed and initialize queues
        dialoguePanel.SetActive(false);
        lines = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        // make cursor visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // stop time and open menu
        dialoguePanel.SetActive(true);
        Time.timeScale = 0f;

        // clear queues
        lines.Clear();
        names.Clear();

        // add all dialogue lines and names to the queues
        foreach(string line in dialogue.lines)
        {
            lines.Enqueue(line);
        }
        foreach(string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (lines.Count == 0)
        {
            EndDialogue();
            return;
        }

        // set current name and line
        string name = names.Dequeue();
        string line = lines.Dequeue();

        // display on UI
        nameText.text = name;
        StopAllCoroutines();
        StartCoroutine(TypeLine(line));
    }

    // Function that causes letters to appear one after another
    IEnumerator TypeLine (string line)
    {
        dialogueText.text = "";
        foreach(char letter in line.ToCharArray())
        {
            dialogueText.text += letter;

            // wait for 7 frames in between each letter
            for(int i=0; i<7; i++)
            {
                yield return null;
            }
        }
    }

    void EndDialogue()
    {
        // make cursor invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // resume time, and close menu
        dialoguePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
