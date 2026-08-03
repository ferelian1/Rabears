using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearCombat : MonoBehaviour
{

    private BearStats stats;
    private BearVision vision;  
    

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
        
    }

    private void HandleAttack()
    {
        
    }
}
