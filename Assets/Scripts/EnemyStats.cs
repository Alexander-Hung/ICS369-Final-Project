using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth = 50;
    public float currentHealth;

    public Slider enemyHealthBar;
    public Canvas canvas;

    // Called when the game starts
    private void Awake()
    {
        // set health
        currentHealth = maxHealth;

        // set health bar as child of canvas
        canvas = GameObject.Find("HealthBarCanvas").GetComponent<Canvas>();
        enemyHealthBar.transform.SetParent(canvas.transform);

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

    private void Die()
    {
        Destroy(gameObject);
        Destroy(enemyHealthBar.gameObject);
    }

    public float CheckHealth()
    {
        return currentHealth;
    }
}
