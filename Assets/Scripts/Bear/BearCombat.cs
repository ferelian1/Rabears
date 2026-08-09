using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCombat : MonoBehaviour
{

    private BearStats stats;
    private BearVision vision;
    private float cooldownTimer = 0;


    void Update()
    {
        HandleAttack();
    }

    public void Initialize(BearStats stats, BearVision vision)
    {
        this.stats = stats;
        this.vision = vision;
    }

    private void Attack()
    {
        vision.target.GetComponent<PlayerHealth>().TakeDamage(stats.damage);
        cooldownTimer = stats.attackCooldownTimer;

        Debug.Log("Bear attacked player for " + stats.damage + " damage.");
    }

    private void HandleAttack()
    {
        cooldownTimer -= Time.deltaTime; 

        if (CanAttack())
        {
            Attack();
        }
    }

    private bool CanAttack()
    {
        if (vision.target == null)
        {
            return false;
        }

        float playerDistance = Vector2.Distance(transform.position, vision.target.position);

        if ( playerDistance > stats.attackRange || cooldownTimer > 0)
        {
            return false;
        }

        return true;
    }
}
