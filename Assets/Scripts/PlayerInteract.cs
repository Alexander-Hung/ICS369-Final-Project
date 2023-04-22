using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    // UI Text
    public TMP_Text statusText;
    public TMP_Text statusText2;

    public GameObject teleporter;

    void Start()
    {
       teleporter.SetActive(false);    
    }

    public void UnlockDoor(GameObject door)
    {
        // reduce the number of keys
        PlayerStats.instance.currentKeys -= 1;

        // destroy door
        Destroy(door);

        // reset text
        statusText.text = "";

    }

    public void activateTeleporter(GameObject brokenTeleporter)
    {

        //take away all teleport scraps from player
        PlayerStats.instance.currentTeleportScrap -= 1;
        
        //activate teleporter
        teleporter.SetActive(true);
        Destroy(brokenTeleporter);

        // reset text
        statusText2.text = "";

    }


    void OnTriggerEnter(Collider col)
    {
        // If near locked door with key
        if (col.tag == "lockedDoor" && PlayerStats.instance.currentKeys > 0)
        {
            statusText.text = "Press E to unlock";
        }
        // If entering tutorial zone
        else if (col.tag == "tutorialPoint")
        {
            TutorialMenu.instance.OpenTutorial();
        }
        // If entering dialogue zone
        else if (col.tag == "dialoguePoint")
        {
            col.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        //if near broken teleporter with key and with < 3 Teleport Scraps
        else if (col.tag == "brokenTeleporter" && PlayerStats.instance.currentTeleportScrap < 3)
        {
            Debug.Log("no scraps");
            statusText2.text = "Loot 3 Teleport Scraps to Activate Teleporter!";
        }

        //if near broken teleporter with key and with 3 teleport scraps
        else if (col.tag == "brokenTeleporter" && PlayerStats.instance.currentTeleportScrap == 3)
        {
            Debug.Log("yay scraps");
            statusText2.text = "Press Q to activate Teleporter!";
        }
    }

    void OnTriggerStay(Collider col)
    {

        // If near locked door with key
        if (col.tag == "lockedDoor" && PlayerStats.instance.currentKeys > 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UnlockDoor(col.gameObject);
            }
        }


        if (col.tag == "brokenTeleporter" && PlayerStats.instance.currentTeleportScrap == 3)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                activateTeleporter(col.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "lockedDoor")
        {
            statusText.text = "";
        }

        else if (col.tag =="brokenTeleporter")
        {
            statusText2.text = "";
        }

    }
}
