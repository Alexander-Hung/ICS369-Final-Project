using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// code from: https://youtu.be/UjkSFoLxesw222 and https://youtu.be/sPiVz1k-fEs

public class Enemy : MonoBehaviour
{
    // define variables
    public NavMeshAgent agent;
    public Transform playerTransform;
    public LayerMask whatIsGround, whatIsPlayer;

    // Attacking
    public int attackStrength;
    public float attackInterval;
    bool attacked;
    public Transform attackPoint;
    public float attackPointRange;

    public float sightRange, attackingRange;
    public bool playerInSightRange, playerInAttackingRange;

    // Called when the game starts
    private void Awake()
    {
        // find player
        playerTransform = GameObject.Find("Player").transform;

        // set agent
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        // check if the player is in range to chase or attack
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackingRange = Physics.CheckSphere(transform.position, attackingRange, whatIsPlayer);

        // enemy behavior
        if (playerInSightRange && !playerInAttackingRange)
        {
            Chase();
        }
        if (playerInSightRange && playerInAttackingRange)
        {
            Attack();
        }
    }

    private void Chase()
    {
        // make enemy follow player
        agent.SetDestination(playerTransform.position);
    }

    private void Attack()
    {
        // stop enemy
        agent.SetDestination(transform.position);
        // face player
        transform.LookAt(playerTransform);
        // attack
        if (!attacked)
        {
            attacked = true;

            // detect if player is in range of attack point
            Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackPointRange, whatIsPlayer);

            // if player is in range, damage
            foreach(Collider player in hitPlayer)
            {
                Debug.Log("Player Hit");
                PlayerStats.instance.TakeDamage(attackStrength);
            }


            // can attack again after the specified interval
            Invoke(nameof(ResetAttack), attackInterval);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }

}
