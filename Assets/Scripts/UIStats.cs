using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStats : MonoBehaviour
{
    public GameObject player;
    int currHealth = 0;
    int currArmor = 0;
    int currKeys = 0;
    int currLevel = 0;

    void Start()
    {
        currHealth = player.GetComponent<PlayerStats>().CheckHealth();
        currArmor = player.GetComponent<PlayerStats>().CheckArmor();
        currKeys = player.GetComponent<PlayerStats>().CheckKey();
        currLevel = player.GetComponent<GetItem>().CheckLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
