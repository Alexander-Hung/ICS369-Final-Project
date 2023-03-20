using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code from https://youtu.be/sPiVz1k-fEs

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public GameObject currentWeapon;

    // Called when the game starts
    private void Awake()
    {
        // set health
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        Debug.Log("Game Over");
    }

}
