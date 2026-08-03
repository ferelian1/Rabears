using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth { get; private set; }
    private float currentHealth;
    private float maxHealth = 100f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void Initialize(float initialHealth)
    {
        currentHealth = initialHealth;
        playerHealth = currentHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        playerHealth = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        playerHealth = currentHealth;
    }

    private void Die()
    {
        // Handle player death logic here
        Debug.Log("Player has died.");
    }
}
