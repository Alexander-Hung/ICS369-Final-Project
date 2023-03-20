using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public Weapon weaponScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, weaponContainer, playerCamera;

    public bool equipped;
    public static bool slotFull;
    
    public GameObject playerObj;

    private void Start()
    {
        // Setup
        if (!equipped)
        {
            weaponScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        if (equipped)
        {
            weaponScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        // Make weapon a child of camera and move to default position
        transform.SetParent(weaponContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);


        // Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        // Enable script 
        weaponScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        // Remove weapon as child camera and move to position on the floor
        transform.SetParent(null);
        transform.localPosition = gameObject.GetComponent<Weapon>().spawnPoint.position;
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        // Make Rigidbody not kinematic and BoxCollider normal
        rb.isKinematic = false;
        coll.isTrigger = false;

        // Disable script 
        weaponScript.enabled = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // If interacting with player
        if (collision.collider.gameObject.tag == "Player")
        {
            playerObj = collision.collider.gameObject;

            if (!equipped && !slotFull) {
                // set the colliding weapon as the player's current weapon
                playerObj.GetComponent<PlayerAttack>().currentWeapon = gameObject;
                // Update the player's attacking stats
                playerObj.GetComponent<PlayerAttack>().UpdateStats();
                // pick up
                PickUp(); 
            }
            if (!equipped && slotFull) {
                // drop the player's current weapon
                playerObj.GetComponent<PlayerAttack>().currentWeapon.GetComponent<PlayerPickUp>().Drop();
                // set the colliding weapon as the player's current weapon
                playerObj.GetComponent<PlayerAttack>().currentWeapon = gameObject;
                // Update the player's attacking stats
                playerObj.GetComponent<PlayerAttack>().UpdateStats();
                // pick up
                PickUp();
            }
        }
    }
}
