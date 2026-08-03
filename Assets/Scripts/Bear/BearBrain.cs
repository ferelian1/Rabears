using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BearBrain : MonoBehaviour
{
    private BearStats stats;
    private BearMovement movement;
    private BearVision vision;
    private Vector2 playerPosition;
    private BearState currentState;

    public void Initialize(BearStats stats, BearMovement movement, BearVision vision, BearState currentState)
    {
        this.stats = stats;
        this.movement = movement;
        this.vision = vision;
        this.currentState = currentState;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        vision.UpdateTarget(); 
        
        if(vision.target != null)
        {
            currentState = BearState.Chasing;
            Vector2 direction = vision.target.position - transform.position;
            movement.Move(direction, stats.walkSpeed, stats.acceleration);
        }
        else
        {
            currentState = BearState.Idle;
            movement.Stop();
        }
    }

   

}
