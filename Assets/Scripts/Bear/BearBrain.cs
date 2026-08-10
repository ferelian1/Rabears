using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public enum BearState
{
    Idle,
    Chasing,
    Attacking
}

public class BearBrain : MonoBehaviour
{
    private BearStats stats;
    private BearMovement movement;
    private BearVision vision;
    private Vector2 playerPosition;
    private BearState currentState = BearState.Idle;

    [Inject]
    public void Initialize(BearStats stats, BearMovement movement, BearVision vision)
    {
        this.stats = stats;
        this.movement = movement;
        this.vision = vision;
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
