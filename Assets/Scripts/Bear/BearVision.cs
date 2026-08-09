using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;

public class BearVision : MonoBehaviour
{

    public Transform target { get; private set; }
    private Transform playerTransform;
    private BearStats bearStats;

    private Action OnPlayerDetected;

    [Inject]
    public void Initialize(Transform player, BearStats stats)
    {
        playerTransform = player;
        bearStats = stats;
    }

    public void UpdateTarget()
    {
        if (playerTransform != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position); //calculate the distance between the bear and the player
            
            if (distanceToPlayer <= bearStats.detectionRange)
            {
                target = playerTransform;
            }
            else
            {
                target = null;
            }
        }
    }
}


