using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    public Animator transition;
    public float transitionTime = 1f;

    private void Awake()
    {
        instance = this;

        // StartCoroutine(PlayDialogue());
    }

    public IEnumerator LoadLevel(string sceneName)
    {
        // play the fade animation
        transition.SetTrigger("Play");
        yield return new WaitForSeconds(transitionTime);

        // load new scene
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator PlayDialogue()
    {
        yield return new WaitForSeconds(3);
        // if in Scene2, play the intro dialogue
        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            gameObject.GetComponent<DialogueTrigger>().dialogueName = "introDialogue";
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}
