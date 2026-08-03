using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float CurrentHealth { get; private set; }
    private float maxHealth = 100f;

    void Start()
    {
        Initialize(maxHealth);
    }

    public void Initialize(float initialHealth)
    {
        CurrentHealth = initialHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        CurrentHealth += amount;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, maxHealth);
    }

    private void Die()
    {
        // Handle player death logic here
        Debug.Log("Player has died.");
    }
}
