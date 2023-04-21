using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueCues : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(PlayDialogue());
    }

    public IEnumerator PlayDialogue()
    {
        yield return new WaitForSeconds(3);
        // if in Main Scene, play the intro dialogue
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            gameObject.GetComponent<DialogueTrigger>().dialogueName = "introDialogue";
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}
