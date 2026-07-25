using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] private BearStats stats;
    private BearBrain brain;
    private BearMovement movement;
    
    private BearVision vision;

    private Rigidbody2D rb;
    private Transform player;


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
        brain.Initialize(stats, movement, vision);
        movement.Initialize(rb);
        vision.Initialize(player, stats);
    }
}
