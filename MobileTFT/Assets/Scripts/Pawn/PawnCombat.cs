using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnCombat : MonoBehaviour
{
    private PawnStats stats;

    private void Awake()
    {
        stats = GetComponent<PawnStats>();
    }

    private void OnDeath()
    {
        GetComponent<Pawn>().GetMovement().GetSlot().RemovePawn();
        this.gameObject.SetActive(false);
    }

    public bool RecieveDamage(float amount)
    {
        float newHealth = stats.GetCurrentHealth() - amount;
        stats.SetCurrentHealth(newHealth);
        
        if(newHealth <= 0)
        {
            OnDeath();
            return true;
        }
        return false;
    }

    public void DealDamage(Pawn targetPawn)
    {
        if(targetPawn.GetCombat().RecieveDamage(stats.GetDamage()))
        {
            // killed
            stats.AddKillToCount();
        }
    }
}
