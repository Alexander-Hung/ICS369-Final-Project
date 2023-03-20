using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject currentWeapon;
    public int attackStrength;

    public Transform attackPoint;
    public float attackPointRange;
    public LayerMask whatIsEnemy;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("mouse 0") && currentWeapon)
        {
            Attack();
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

    public void UpdateStats()
    {
        attackStrength = currentWeapon.GetComponent<Weapon>().weaponPower;
        attackPointRange = currentWeapon.GetComponent<Weapon>().weaponRange;
    }
}
