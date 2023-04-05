using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public Weapon weaponScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, playerPrefab;

    public bool equipped;
    public static bool slotFull;
    
    public GameObject playerObj;
    public Vector3 weaponPosition, weaponRotation;

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
        transform.SetParent(playerPrefab);
        transform.localPosition = weaponPosition;
        transform.localEulerAngles = weaponRotation;


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
                PlayerAttack.instance.currentWeapon = gameObject;
                // Update the player's attacking stats
                PlayerAttack.instance.UpdateStats();
                // pick up
                PickUp(); 
            }
            if (!equipped && slotFull) {
                // drop the player's current weapon
                PlayerAttack.instance.currentWeapon.GetComponent<PlayerPickUp>().Drop();
                // set the colliding weapon as the player's current weapon
                PlayerAttack.instance.currentWeapon = gameObject;
                // Update the player's attacking stats
                PlayerAttack.instance.UpdateStats();
                // pick up
                PickUp();
            }
        }
    }
}
