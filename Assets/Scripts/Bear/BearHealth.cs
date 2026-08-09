using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHealth : MonoBehaviour
{
    public float CurrentHealth { get; private set; }

    private BearStats stats;

    public void Initialize(BearStats stats)
    {
        this.stats = stats;
        CurrentHealth = stats.maxHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        Debug.Log(stats.bearName + " took " + damage + " damage. Current health: " + CurrentHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, stats.maxHealth);
    }

    private void Die()
    {
        // Handle player death logic here
        Debug.Log(stats.bearName + " has died.");
    }
}
