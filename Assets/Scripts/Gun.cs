using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{

    public static Gun instance;

    // Called when the game starts
    private void Awake()
    {
        instance = this;
        weaponPower = 40;
        weaponRange = 1;
        isGun = true;
    }

    public void AddGunPower()
    {
        //if player has Gun
        weaponPower += 5;
        Debug.Log("Gun Power: " + weaponPower);
    }

    public override void DebugMessage()
    {
        Debug.Log("gun selected");
    }
}
