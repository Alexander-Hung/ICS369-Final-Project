using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerWeapon : Weapon
{
    // Called when the game starts
    private void Awake()
    {
        weaponPower = 20;
        weaponRange = 3;
        isGun = false;
    }

    public override void DebugMessage()
    {
        Debug.Log("dagger weapon selected");
    }
}
