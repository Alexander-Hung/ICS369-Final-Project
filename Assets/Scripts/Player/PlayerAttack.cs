using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject currentWeapon;
    public ShootWeapon shootWeapoScriptn;
    public int attackStrength;

    public Transform attackPoint;
    public float attackPointRange;
    public LayerMask whatIsEnemy;

    public static PlayerAttack instance;

    public Transform bullet;

    private void Start()
    {
        shootWeapoScriptn = GetComponent<ShootWeapon>();
        shootWeapoScriptn.enabled = false;
    }

    // Called when the game starts
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("mouse 0") && (currentWeapon == GameObject.Find("Dagger") || currentWeapon == GameObject.Find("Saber")))
        {
            shootWeapoScriptn.enabled = false;
            Attack();
        } else if (currentWeapon == GameObject.Find("Gun"))
        {
            shootWeapoScriptn.enabled = true;
            Shoot();
        }
    }

    public void Attack()
    {
        // detect if enemy is in range of attack point
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackPointRange, whatIsEnemy);

        // if player is in range, damage
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Enemy Hit!");
            enemy.GetComponent<EnemyStats>().TakeDamage(attackStrength);
        }
    }

    public void Shoot()
    {
        // detect if enemy is in range of attack point
        Collider[] hitEnemies = Physics.OverlapSphere(bullet.position, attackPointRange, whatIsEnemy);

        // if player is in range, damage
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Enemy Hit!");
            enemy.GetComponent<EnemyStats>().TakeDamage(attackStrength);
        }
    }

    public void UpdateStats()
    {
        attackStrength = currentWeapon.GetComponent<Weapon>().weaponPower;
        attackPointRange = currentWeapon.GetComponent<Weapon>().weaponRange;
    }
}
