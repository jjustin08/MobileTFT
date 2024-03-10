using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Pawn parentPawn;

    private Slot startingSlot;

    private bool isCombatMode = false;


    private float moveTimerMax = 2;
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
        // check if target to attack
        TilePosition tileToAttack;
        tileToAttack = MovementUtil.Instance.GetTargetInRange(
            parentPawn.GetStats().GetRange(),
            parentPawn.GetMovement().GetSlot().GetTilePos()); // to long

        if (tileToAttack != null)
        {
            if (Timer(ref attackTimerMax, ref attackTimerCurrent))
                return true;

            
            //parentPawn.GetCombat().DealDamage(tileToAttack.GetSlot().GetPawn());
            //print("attack");
            return true;
        }
        return false;
    }

    private void MovementUpdate()
    {
        if (Timer(ref moveTimerMax, ref moveTimerCurrent))
            return;


        TilePosition tileToMove;
        //tileToMove = MovementUtil.Instance.GetNextMovementTile(parentPawn.GetMovement().GetSlot().GetTilePos()); // to long
        tileToMove = MovementUtil.Instance.AStarNextMoveTile(parentPawn.GetMovement().GetSlot().GetTilePos()); // to long


        
        // move
        if (tileToMove != null)
        {
            parentPawn.GetMovement().MoveToSlot(tileToMove.GetSlot());

        }
    }

    public void ToggleCombatMode(bool toggle)
    {
        isCombatMode = toggle;

        if(toggle)
        {
            startingSlot = parentPawn.GetMovement().GetSlot();
        }
        else
        {
            parentPawn.GetMovement().MoveToSlot(startingSlot);

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
