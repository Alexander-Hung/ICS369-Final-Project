using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float saberCoolDown;
    public float daggerCoolDown;
    public GameObject currentWeapon;
    public ShootWeapon shootWeapoScriptn;
    public int attackStrength;

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
    }

    // Called when the game starts
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("mouse 0") && readyToAttack && (currentWeapon == GameObject.Find("Dagger") || currentWeapon == GameObject.Find("Saber")))
        {
            shootWeapoScriptn.enabled = false;
            readyToAttack = false;

            Attack();

            if(currentWeapon == GameObject.Find("Saber"))
            {
                Invoke(nameof(ResetCoolDown), saberCoolDown);
            } else if (currentWeapon == GameObject.Find("Dagger"))
            {
                Invoke(nameof(ResetCoolDown), daggerCoolDown);
            }
        }
        else if (currentWeapon == GameObject.Find("Gun"))
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
            Debug.Log("Enemy Hit!");
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
