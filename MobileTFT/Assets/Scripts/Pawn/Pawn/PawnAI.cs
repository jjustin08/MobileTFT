using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAI : MonoBehaviour
{
    private Pawn parentPawn;

    private bool isCombatMode = false;

    private Pawn lastTargetPawn = null;


    // Timers
    private float moveTimerMax = 0.5f;
    private float moveTimerCurrent = 0;
    
    private float attackTimerMax = 1;
    private float attackTimerCurrent = 0;
    private void Start()
    {
        parentPawn = GetComponent<Pawn>();
        attackTimerMax = parentPawn.GetStats().GetAttackTime();
        moveTimerMax = parentPawn.GetStats().GetMoveTime();
    }

    private void Update()
    {
        if (!isCombatMode)
            return;

        if (AttackUpdate())
            return;

        MovementUpdate();   
    }

    public SlotPosition GetTarget()
    {
        SlotPosition slotToAttack;


        if (lastTargetPawn == null)
        {
            slotToAttack =
            GridUtil.Instance.GetTargetInRange(
            parentPawn.GetStats().GetRange()
            , parentPawn.GetMovement().GetSlot());
        }
        else
        {
            if (GridUtil.Instance.IsSlotInRange(parentPawn.GetStats().GetRange()
            , parentPawn.GetMovement().GetSlot(), lastTargetPawn.GetMovement().GetSlot()) &&
            lastTargetPawn.GetStats().GetCurrentHealth() > 0)
            {
                slotToAttack = lastTargetPawn.GetMovement().GetSlot().GetSlotPos();

            }
            else
            {
                lastTargetPawn = null;
                slotToAttack =
                GridUtil.Instance.GetTargetInRange(
                parentPawn.GetStats().GetRange()
                , parentPawn.GetMovement().GetSlot());
            }

        }

        return slotToAttack;
    }

    public void Attack(SlotPosition slotToAttack)
    {
        // its a bit funky would be nice to add lerp here too
        Vector3 direction = (slotToAttack.transform.position - transform.position).normalized;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        lastTargetPawn = slotToAttack.GetSlot().GetPawn();
        parentPawn.GetCombat().DealDamage(lastTargetPawn);
    }

    private bool AttackUpdate()
    {
        SlotPosition slotToAttack = GetTarget();

        if (slotToAttack != null)
        {
            if (parentPawn.GetStats().IsManaFull())
            {
                //activate ability
                parentPawn.GetStats().SetCurrentMana(0);
                parentPawn.GetPawnSO().ability.Ability(parentPawn);
                return true;
            }
        }


        slotToAttack = GetTarget();
        if (slotToAttack != null) 
        {
            if (Timer(attackTimerMax, ref attackTimerCurrent))
                return true;

            Attack(slotToAttack);
            parentPawn.GetStats().AddMana();


            return true;
        }
        else
        {
            attackTimerCurrent = attackTimerMax;
        }

        
        return false;
    }


    private void MovementUpdate()
    {
        if (Timer(moveTimerMax, ref moveTimerCurrent))
            return;

        SlotPosition tileToMove;
        tileToMove = GridUtil.Instance.AStarNextMoveTile(parentPawn.GetMovement().GetSlot());

        if (tileToMove != null)
        {
            parentPawn.GetMovement().MoveToSlot(tileToMove.GetSlot());
        }
        else
        {
            moveTimerCurrent = moveTimerMax;
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

        attackTimerMax = parentPawn.GetStats().GetAttackTime();
        moveTimerMax = parentPawn.GetStats().GetMoveTime();
    }

    public bool Timer(float max, ref float current)
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
