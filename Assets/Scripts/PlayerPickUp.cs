using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public Weapon weaponScript;
    public GameObject currentWeapon;

    public bool isEquipped;
    public static bool isHoldingWeapon;

    GameObject player;
    public Transform weaponContainer;

    // Called when the game starts
    private void Awake()
    {
        weaponScript = gameObject.GetComponent<Weapon>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // If interacting with player
        if (collision.collider.gameObject.tag == "Player")
        {
            player = collision.collider.gameObject;

            // if not holding any weapon, equip
            if (!isEquipped && !isHoldingWeapon)
            {
                isEquipped = true;
                isHoldingWeapon = true;
                player.GetComponent<PlayerStats>().currentWeapon = gameObject;
                // make weapon a child of player
                gameObject.transform.parent = player.transform.GetChild(1).transform;
                // move weapon to player hand
                gameObject.transform.position = weaponContainer.position;
                weaponScript.DebugMessage();
            }
            // if currently holding another weapon
            if(!isEquipped && isHoldingWeapon)
            {
                // remove original weapon as player child
                player.GetComponent<PlayerStats>().currentWeapon.transform.parent = null;
                // move original weapon back to spawn position
                
                // make weapon a child of player
                gameObject.transform.parent = player.transform.GetChild(1).transform;
                // move weapon to player hand
                gameObject.transform.position = weaponContainer.position;

                weaponScript.DebugMessage();
            }

        }
    }
}
