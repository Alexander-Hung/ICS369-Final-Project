using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueCues : MonoBehaviour
{
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            StartCoroutine(PlayMainSceneDialogue());
        }
        else if (SceneManager.GetActiveScene().name == "BossScene")
        {
            StartCoroutine(PlayEndingSceneDialogue());
        }
    }

    public IEnumerator PlayMainSceneDialogue()
    {
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<DialogueTrigger>().dialogueName = "introDialogue";
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
    }

    public IEnumerator PlayEndingSceneDialogue()
    {
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<DialogueTrigger>().dialogueName = "endDialogue";
        gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();

        // wait until the dialogue finishes
        while (gameObject.GetComponent<DialogueManager>().dialoguePanel.activeInHierarchy)
        {
            yield return null;
        }

        yield return new WaitForSeconds(3);

        // Go to the ending screen
        SceneManager.LoadScene("EndingScene");
    }
}
