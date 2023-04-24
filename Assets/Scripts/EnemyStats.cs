using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50;
    public float currentHealth;

    public GameObject Loot;

    public Slider enemyHealthBar;

    // Called when the game starts
    private void Awake()
    {
        // set health
        currentHealth = maxHealth;

    }

    public void TakeDamage(int damage)
    {
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
