using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BearStats", menuName = "Stats/BearStats", order = 1)]
public class BearStats : ScriptableObject
{
    public string bearName = "";
    public float maxHealth = 100f; // Maximum health of the bear
    public float damage = 10f; //damage dealt by the bear
    public float walkSpeed = 3.5f; //movement speed of the bear
    public float runSpeed = 8f; //chase speed of the bear
    public float acceleration = 5f; //acceleration of the bear
    public float detectionRange = 5f; // range of the bear seeing the player
    public float attackRange = 1f; //range of the bear attacking the player
    public float attackCooldownTimer = 2f; //time between attacks
}

