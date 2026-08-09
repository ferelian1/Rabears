using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class PlayerCombat : MonoBehaviour
{
    private float attackCooldown = 1f; // Cooldown duration in seconds
    private float attackRange = 1.5f; // Attack range in units
    private float attackOffset = 0.5f; // Offset for the attack position
    private float damage = 10f; // Damage dealt per attack
    private float cooldownTimer = 0f; // Timer to track cooldown
    private Vector2 attackDirection = Vector2.right; // Default attack direction

    private PlayerMovement playerMove;
    
    [Inject]
    public void Initialize(PlayerMovement playerMovement)
    {
        // Subscribe to the OnMove event from PlayerMovement
        this.playerMove = playerMovement;
    }


    public void OnAttack(InputAction.CallbackContext context)
    {
        if (CanAttack())
        {
            Attack();
            cooldownTimer = attackCooldown; // Reset the cooldown timer
        }
    }
    
    // Update is called once per frame
    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        attackDirection = playerMove.LastDirection; // Update the attack direction based on the last movement direction
        
        Vector2 attackPosition = (Vector2)transform.position + attackDirection * attackOffset; // Calculate the attack position based on the player's position and the attack direction
        Collider2D[] hitEnemies =Physics2D.OverlapCircleAll(attackPosition, attackRange, LayerMask.GetMask("Enemy")); // Get all enemies within the attack range using OverlapCircleAll

        foreach (Collider2D enemy in hitEnemies)
        {
            // Apply damage to the all enemies within the attack range
            BearHealth bearHealth = enemy.GetComponent<BearHealth>();
            if (bearHealth != null)
            {
                // Apply damage to the bear
                bearHealth.TakeDamage(damage);
            }
        }
    }

    private bool CanAttack()
    {
        return cooldownTimer <= 0;
    }

}
