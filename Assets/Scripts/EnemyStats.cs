using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50;
    public float currentHealth;

    public GameObject Loot;

    // Enemy sound effects
    public AudioSource enemyHurt;
    public float volume = 0.5f;

    public Slider enemyHealthBar;

    // Called when the game starts
    private void Awake()
    {
        // set health
        currentHealth = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        // play EnemyHurt sound
        enemyHurt.PlayOneShot(enemyHurt.clip, volume);
        currentHealth -= damage;
        enemyHealthBar.value = (currentHealth / maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }
    
    public void DropLoot()
    {
        Vector3 position = transform.position; //position of enemy
        GameObject item = Instantiate(Loot, position, Quaternion.identity); //Key Drop
        item.SetActive(true); //set key to active
        Destroy(item, 5f); //destroy after 5 sec
    }

    private void Die()
    {
        Destroy(gameObject);
        DropLoot(); //dropsKey
    }

    public float CheckHealth()
    {
        return currentHealth;
    }
}
