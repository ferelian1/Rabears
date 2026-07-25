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
            Vector2 direction = vision.target.position - transform.position;
            movement.Move(direction, stats.walkSpeed, stats.acceleration);
        }
        else
        {
            movement.Stop();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (vision != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, stats.detectionRange);
        }
    }

}
