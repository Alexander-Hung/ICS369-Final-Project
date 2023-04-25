using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50;
    public float currentHealth;

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

    private void Die()
    {
        Destroy(gameObject);
    }

    public float CheckHealth()
    {
        return currentHealth;
    }
}
