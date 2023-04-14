using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    private GameObject daggerWeapon;
    private GameObject saberWeapon;
    private GameObject gunWeapon;

    private GameObject dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        daggerWeapon = gameObject.GetComponent<PlayerAttack>().daggerWeapon;
        saberWeapon = gameObject.GetComponent<PlayerAttack>().saberWeapon;
        gunWeapon = gameObject.GetComponent<PlayerAttack>().gunWeapon;

        dialogueManager = GameObject.Find("DialogueManager");
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "armorItem")
        {
            Destroy(col.gameObject);

            // trigger dialogue for first armor item
            if (PlayerStats.instance.totalArmor == 0)
            {
                dialogueManager.GetComponent<DialogueTrigger>().dialogueName = "armorDialogue";
                dialogueManager.GetComponent<DialogueTrigger>().TriggerDialogue();
            }

            PlayerStats.instance.AddArmor(); 
        }

        if(col.tag == "healthItem")
        {
            Destroy(col.gameObject);

            // trigger dialogue for first health item
            if (PlayerStats.instance.totalHealthUpgrade == 0)
            {
                dialogueManager.GetComponent<DialogueTrigger>().dialogueName = "healthUpgradeDialogue";
                dialogueManager.GetComponent<DialogueTrigger>().TriggerDialogue();
            }

            PlayerStats.instance.AddHealth(); 
        }
        
        if((col.tag == "saberUpgradeItem") && (PlayerAttack.instance.currentWeapon == saberWeapon))
        {
            Destroy(col.gameObject);
            Destroy(col.gameObject);
            // set saber weapon as inactive, and set gun weapon as active
            saberWeapon.SetActive(false);
            gunWeapon.SetActive(true); 
            // set the player's current weapon and update stats
            PlayerAttack.instance.currentWeapon = gunWeapon; 
            PlayerAttack.instance.UpdateStats();
        }

        if((col.tag == "daggerUpgradeItem") && (PlayerAttack.instance.currentWeapon == daggerWeapon))
        {
            
            Destroy(col.gameObject);
            // set dagger weapon as inactive, and set saber weapon as active
            daggerWeapon.SetActive(false);
            saberWeapon.SetActive(true);
            // set the player's current weapon and update stats
            PlayerAttack.instance.currentWeapon = saberWeapon;
            PlayerAttack.instance.UpdateStats();
        }

        if (col.tag == "keyItem")
        {
            Destroy(col.gameObject);

            // trigger dialogue for first key item
            if (PlayerStats.instance.totalKey == 0)
            {
                dialogueManager.GetComponent<DialogueTrigger>().dialogueName = "keyDialogue";
                dialogueManager.GetComponent<DialogueTrigger>().TriggerDialogue();
            }

            PlayerStats.instance.AddKey();
        }
    }    
}
