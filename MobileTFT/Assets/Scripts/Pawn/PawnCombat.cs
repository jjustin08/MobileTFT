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


    public void RecieveDamage(float amount)
    {
        float newHealth = stats.GetHealth() - amount;
        stats.SetHealth(newHealth);
        
        if(newHealth <= 0)
        {
            GetComponent<Pawn>().GetMovement().GetSlot().RemovePawn();
            this.gameObject.SetActive(false);
        }
    }

    public void DealDamage(Pawn targetPawn)
    {
        targetPawn.GetCombat().RecieveDamage(stats.GetDamage());
    }
}
