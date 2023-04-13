using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberWeapon : Weapon
{
    public static SaberWeapon instance;

    // Called when the game starts
    private void Awake()
    {
        instance = this;
        weaponPower = 10;
        weaponRange = 5;
        isGun = false;
    }

    public void AddSaberPower()
    {
        //if player has saber
        weaponPower += 5;
        Debug.Log("Saber Power: " + weaponPower);
    }

    public override void DebugMessage()
    {
        Debug.Log("Saber weapon selected");
    }
}