using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public static TutorialMenu instance;
    public GameObject tutorialMenu;

    // Start is called before the first frame update
    void Start()
    {
        tutorialMenu.SetActive(false);
        instance = this;
    }

    public void OpenTutorial()
    {
        // make cursor visible
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // stop time and open menu
        tutorialMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseTutorial()
    {
        // make cursor invisible
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // resume time, and close menu
        tutorialMenu.SetActive(false);
        Time.timeScale = 1f;

        // destroy object so tutorial can't be accessed again
        Destroy(gameObject);
    }
}
