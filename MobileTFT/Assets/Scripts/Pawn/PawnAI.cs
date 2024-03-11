using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAI : MonoBehaviour
{
    private Pawn parentPawn;

  

    private bool isCombatMode = false;

    // Timers
    private float moveTimerMax = 0.5f;
    private float moveTimerCurrent = 0;
    
    private float attackTimerMax = 1;
    private float attackTimerCurrent = 0;
    private void Start()
    {
        parentPawn = GetComponent<Pawn>();
        attackTimerMax = parentPawn.GetStats().GetAttackTime();
    }

    private void Update()
    {
        if (!isCombatMode)
            return;

        if (AttackUpdate())
            return;

        MovementUpdate();   
    }

    private bool AttackUpdate()
    {
        SlotPosition slotToAttack;
        
        slotToAttack = 
            GridUtil.Instance.GetTargetInRange(
            parentPawn.GetStats().GetRange()
            ,parentPawn.GetMovement().GetSlot()); 

        if (slotToAttack != null)
        {
            if (Timer(ref attackTimerMax, ref attackTimerCurrent))
                return true;

            parentPawn.GetCombat().DealDamage(slotToAttack.GetSlot().GetPawn());
            return true;
        }
        return false;
    }

    private void MovementUpdate()
    {
        if (Timer(ref moveTimerMax, ref moveTimerCurrent))
            return;

        SlotPosition tileToMove;
        tileToMove = GridUtil.Instance.AStarNextMoveTile(parentPawn.GetMovement().GetSlot());

        if (tileToMove != null)
        {
            parentPawn.GetMovement().MoveToSlot(tileToMove.GetSlot());
        }
    }

    public void ToggleCombat(bool toggle)
    {
        isCombatMode = toggle;

        if(!toggle)
        {
            attackTimerCurrent = 0;
            moveTimerCurrent = 0;
        }
    }

    public bool Timer(ref float max,ref float current)
    {
        current -= Time.deltaTime;
        if (current <= 0)
        {
            current = max;
            return false;
        }
        return true;
    }
}
