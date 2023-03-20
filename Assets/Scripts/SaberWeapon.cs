using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaberWeapon : Weapon
{
    // Called when the game starts
    private void Awake()
    {
        weaponPower = 10;
        weaponRange = 5;
        isGun = false;
        spawnPoint = GameObject.Find("SaberSpawnPoint").transform;
    }

    public override void DebugMessage()
    {
        Debug.Log("Saber weapon selected");
    }
}