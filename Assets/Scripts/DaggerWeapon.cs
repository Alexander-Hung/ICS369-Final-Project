using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerWeapon : Weapon
{

    public static DaggerWeapon instance;

    // Called when the game starts
    private void Awake()
    {
        instance = this;
        weaponPower = 10;
        weaponRange = 3;
        isGun = false;
    }

    public void AddDaggerPower()
    {
        //if player has dagger
        weaponPower += 5;
        Debug.Log("Dagger Power: " + weaponPower);
    }

    public override void DebugMessage()
    {
        Debug.Log("dagger weapon selected");
    }
}
