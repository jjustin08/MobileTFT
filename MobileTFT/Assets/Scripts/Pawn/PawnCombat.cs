using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnCombat : MonoBehaviour
{
    private PawnStats stats;
    private Pawn targetPawn;


    private float counter = 0;
    private void Awake()
    {
        stats = GetComponent<PawnStats>();
    }

    private void Update()
    {
        if(targetPawn != null) 
        {
            AttackUpdate();
        }
    }

    private void AttackUpdate()
    {
        if(counter <= stats.GetAttackTime())
        {
            counter += Time.deltaTime;
        }
        else
        {
            counter = 0;
            DealDamage();
        }
    }

    public void SetTarget(Pawn newTarget)
    {
        targetPawn = newTarget;
    }

    public void RecieveDamage(float amount)
    {
        float newHealth = stats.GetHealth() - amount;
        stats.SetHealth(newHealth);
        
        if(newHealth<= 0)
        {
            Destroy(gameObject);
        }
    }

    private void DealDamage()
    {
        targetPawn.GetCombat().RecieveDamage(stats.GetDamage());
    }
}
