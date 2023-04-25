using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float saberCoolDown;
    public float daggerCoolDown;
    public ShootWeapon shootWeapoScriptn;
    public int attackStrength;

    public GameObject currentWeapon;
    public GameObject daggerWeapon;
    public GameObject saberWeapon;
    public GameObject gunWeapon;

    //attack audio source
    public AudioSource playerAttacks;

    //weapon sound effects
    public AudioClip daggerStab;

    public Transform attackPoint;
    public float attackPointRange;
    public LayerMask whatIsEnemy;

    bool readyToAttack;

    public static PlayerAttack instance;

    public Transform bullet;

    private void Start()
    {
        shootWeapoScriptn = GetComponent<ShootWeapon>();
        shootWeapoScriptn.enabled = false;
        readyToAttack = true;

        daggerWeapon.SetActive(true);
        currentWeapon = daggerWeapon;
        UpdateStats();
    }

    // Called when the game starts
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("mouse 0") && readyToAttack && (currentWeapon == daggerWeapon || currentWeapon == saberWeapon))
        {
            shootWeapoScriptn.enabled = false;
            readyToAttack = false;

            //Attack();

            if(currentWeapon == saberWeapon)
            {
                Invoke(nameof(ResetCoolDown), saberCoolDown);
            } else if (currentWeapon == daggerWeapon)
            {
                Attack();
                playerAttacks.PlayOneShot(daggerStab, 1.0f);
                Invoke(nameof(ResetCoolDown), daggerCoolDown);
            }
        }
        else if (currentWeapon == gunWeapon)
        {
            shootWeapoScriptn.enabled = true;
            Shoot();
        }
    }

    public void Attack()
    {
        Debug.Log("Attack");
        // detect if enemy is in range of attack point
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackPointRange, whatIsEnemy);

        // if player is in range, damage
        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Enemy Hit!");
            enemy.GetComponent<EnemyStats>().TakeDamage(attackStrength);
            if (enemy.GetComponent<EnemyStats>().currentHealth > 0)
            {
                StartCoroutine(enemy.GetComponent<Enemy>().Stun());
            }
        }
    }

    public void Shoot()
    {
        // detect if enemy is in range of attack point
        Collider[] hitEnemies = Physics.OverlapSphere(bullet.position, attackPointRange, whatIsEnemy);

        // if player is in range, damage
        foreach (Collider enemy in hitEnemies)
        {
            // Debug.Log("Enemy Hit!");
            enemy.GetComponent<EnemyStats>().TakeDamage(attackStrength);
        }
    }

    public void UpdateStats()
    {
        attackStrength = currentWeapon.GetComponent<Weapon>().weaponPower;
        attackPointRange = currentWeapon.GetComponent<Weapon>().weaponRange;
    }

    private void ResetCoolDown()
    {
        readyToAttack = true;
    }
}
