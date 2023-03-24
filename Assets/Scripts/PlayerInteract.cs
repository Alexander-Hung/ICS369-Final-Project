using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    // UI Text
    public TMP_Text statusText;

    public void UnlockDoor(GameObject door)
    {
        // reduce the number of keys
        PlayerStats.instance.currentKeys -= 1;

        // destroy door
        Destroy(door);

        // reset text
        statusText.text = "";

    }

    // Interacting with locked doors
    void OnTriggerEnter(Collider col)
    {
        // If near locked door with key
        if (col.tag == "lockedDoor" && PlayerStats.instance.currentKeys > 0)
        {
            statusText.text = "Press E to unlock";
        }
    }

    // while in range of the locked door
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
    }

    // reset text when leaving locked door
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "lockedDoor")
        {
            statusText.text = "";
        }
    }
}
