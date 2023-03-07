using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// code from: https://youtu.be/UjkSFoLxesw222

public class Enemy : MonoBehaviour
{
    // define variables
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public float attackInterval;
    bool attacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Called when the game starts
    private void Awake()
    {
        // find player
        player = GameObject.Find("Player").transform;
        // set agent
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        // check if the player is in range to chase or attack
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        // enemy behavior
        if (playerInSightRange && !playerInAttackRange)
        {
            Chase();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            Attack();
        }
    }

    private void Chase()
    {
        // make enemy follow player
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        // stop enemy
        agent.SetDestination(transform.position);
        // face player
        transform.LookAt(player);
        // attack
        if (!attacked)
        {
            attacked = true;
            // add code for attacking player here
            Debug.Log("attacked");
            // can attack again after the specified interval
            Invoke(nameof(ResetAttack), attackInterval);
        }
    }

    private void ResetAttack()
    {
        attacked = false;
    }
}
