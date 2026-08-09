using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 2.5f;
    [SerializeField] private float runSpeed = 3f;
    [SerializeField] private float acceleration = 10f;

    private Vector2 direction;

    public Vector2 LastDirection { get; private set; } = Vector2.right;


    private Rigidbody2D rb;
   
    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {
        CalculateSpeed();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>().normalized;   
        LastDirection = direction != Vector2.zero ? direction : LastDirection; // Update LastDirection only when there's input and keep the last direction when there's no input
    }

    private void CalculateSpeed()
    {
        Vector2 currentSpeed = rb.velocity;
        Vector2 targetSpeed = direction * walkSpeed;

        rb.velocity = Vector2.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
    }
}
