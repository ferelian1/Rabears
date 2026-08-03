using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BearState
{
    Idle,
    Chasing,
    Attacking
}

public class Bear : MonoBehaviour
{
    [SerializeField] private BearStats stats;
    private BearBrain brain;
    private BearMovement movement;

    private BearVision vision;

    private Rigidbody2D rb;
    private Transform player;

    private BearState currentState = BearState.Idle;
    


    private void Awake()
    {
        brain = GetComponent<BearBrain>();
        movement = GetComponent<BearMovement>();
        rb = GetComponent<Rigidbody2D>();
        vision = GetComponent<BearVision>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Start()
    {
        brain.Initialize(stats, movement, vision, currentState);
        movement.Initialize(rb);
        vision.Initialize(player, stats);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats.detectionRange);

    }
}
