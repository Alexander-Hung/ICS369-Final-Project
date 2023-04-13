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

            Attack();

            if(currentWeapon == saberWeapon)
            {
                Invoke(nameof(ResetCoolDown), saberCoolDown);
            } else if (currentWeapon == daggerWeapon)
            {
                Invoke(nameof(ResetCoolDown), daggerCoolDown);
            }
        }
        else if (currentWeapon == gunWeapon)
        {
            gameObject.GetComponent<SwitchCam>().GetFirstPersonCam().gameObject.SetActive(true);
            gameObject.GetComponent<SwitchCam>().GetThirdPersonCam().gameObject.SetActive(false);
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
