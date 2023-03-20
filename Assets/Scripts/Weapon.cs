using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponPower;
    public int weaponRange;
    public bool isGun;
    public Transform spawnPoint;

    public virtual void DebugMessage() 
    {
        Debug.Log("Main weapon class");
    }
}
