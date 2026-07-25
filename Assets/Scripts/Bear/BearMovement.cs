using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BearMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed;
    private float acceleration;

    public void Initialize(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
    }

    private void FixedUpdate()
    {
        CalculateSpeed();
    }
    public void Move(Vector2 direction, float moveSpeed, float acceleration)
    {
        this.direction = direction.normalized;
        this.moveSpeed = moveSpeed;
        this.acceleration = acceleration;
        //rb.velocity = direction.normalized * moveSpeed;
        //rb.velocity = Vector2.MoveTowards(rb.velocity, direction * moveSpeed, acceleration * Time.deltaTime);
    }

    private void CalculateSpeed()
    {
        Vector2 currentSpeed = rb.velocity;
        Vector2 targetSpeed = direction * moveSpeed;

        rb.velocity = Vector2.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
    }

    public void Stop()
    {
        rb.velocity = Vector2.zero;
    }

    public void Rotate(Vector2 direction)
    {
        // adding for sprite flip
    }
}
