using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// code from https://youtu.be/sPiVz1k-fEs

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public int maxHealth = 300;
    int currentHealth;

    public int maxArmor = 3;
    int currentArmor;

    public int currentKeys;

    // Called when the game starts
    private void Awake()
    {
        // set health
        currentHealth = 100;
        currentArmor = 0;
        currentKeys = 0;
        //set player instance
        instance = this;
    }

    void Start()
    {
        //healthText.text = currentHealth.ToString() + " HP";
    }

    public void TakeDamage(int damage)
    {
        if(currentArmor == 3){
            currentArmor -= 1;
            Debug.Log("Player Armor: " + currentArmor);
            Debug.Log("Player Health: " + currentHealth);
        }
        else if(currentArmor == 2){
            currentArmor -= 1;
            Debug.Log("Player Armor: " + currentArmor);
            Debug.Log("Player Health: " + currentHealth);
        }
        else if(currentArmor == 1){
            currentArmor -= 1;
            Debug.Log("Player Armor: " + currentArmor);
            Debug.Log("Player Health: " + currentHealth);
        }                 
        else if(currentArmor == 0)
        {
            currentHealth -= damage;
            Debug.Log("Player Armor: " + currentArmor);
            Debug.Log("Player Health: " + currentHealth);
        }
        

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    public void AddHealth()
    {
        currentHealth += 10;
        Debug.Log("Player Health: " + currentHealth);
        //healthText.text = currentHealth.ToString() + " HP";
    }

    public void AddArmor()
    {
        if(currentArmor < 3)
        {
            currentArmor += 1;
            Debug.Log("Player Armor: " + currentArmor);
        }
        else 
        {
            Debug.Log("Max Armor: 3");
        }
    }

    public void AddKey()
    {
        currentKeys += 1;
        Debug.Log("Player Keys: " + currentKeys);
    }

    private void Die()
    {
        Debug.Log("Game Over");
    }

}
