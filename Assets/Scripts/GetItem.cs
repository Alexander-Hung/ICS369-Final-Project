using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "armorItem")
        {
            Destroy(col.gameObject);
            PlayerStats.instance.AddArmor(); 
        }

        if(col.tag == "healthItem")
        {
            Destroy(col.gameObject);
            PlayerStats.instance.AddHealth(); 
        }
        
        if(col.tag == "saberUpgradeItem")
        {
            Destroy(col.gameObject);
            SaberWeapon.instance.AddSaberPower();
            PlayerAttack.instance.UpdateStats();
        }

        if(col.tag == "daggerUpgradeItem")
        {
            Destroy(col.gameObject);
            DaggerWeapon.instance.AddDaggerPower();
            PlayerAttack.instance.UpdateStats();
        }

        if (col.tag == "keyItem")
        {
            Destroy(col.gameObject);
            PlayerStats.instance.AddKey();
        }
    }    
}
