using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PawnAI
{
    private Pawn parentPawn;

    private Pawn lastTargetPawn = null;


    // Timers
    private float moveTimerMax = 0.5f;
    private float moveTimerCurrent = 0;

    private float attackTimerMax = 1;
    private float attackTimerCurrent = 0;

    public PawnAI(Pawn parent)
    {
        parentPawn = parent;
        //attackTimerMax = parentPawn.GetStats().GetAttackTime();
       // moveTimerMax = parentPawn.GetStats().GetMoveTime();
    }


    public void AIUpdate(List<Pawn> allPawns)
    {
        if (AttackUpdate(allPawns))
            return;

        MovementUpdate();
    }

    public Pawn GetTarget(List<Pawn> allPawns)
    {
        Pawn pawnToAttack = null;


        if (lastTargetPawn == null)
        {
            pawnToAttack = Grid.GetTargetInRange(pawnToAttack.pawnStats.GetRange(), pawnToAttack, allPawns);
        }
        else
        {
            if (Grid.IsSlotInRange(parentPawn.pawnStats.GetRange(), parentPawn.combatPosition, lastTargetPawn.combatPosition)
                && lastTargetPawn.pawnStats.GetHealth() > 0)
            {
                pawnToAttack = lastTargetPawn;
            }
            else
            {
                pawnToAttack = Grid.GetTargetInRange(pawnToAttack.pawnStats.GetRange(), pawnToAttack, allPawns);
            }
        }

        lastTargetPawn = pawnToAttack;
        return pawnToAttack;
    }

    public void Attack(Pawn pawnToAttack)
    {
        //posbile make a seperate scritp for this
        pawnToAttack.pawnStats.SetHealth(pawnToAttack.pawnStats.GetHealth() - parentPawn.pawnStats.GetDamage());

        if(pawnToAttack.pawnStats.GetHealth() <= 0)
        {
            //kill the pawn
            lastTargetPawn = null;
            Combat.KillPawn(pawnToAttack);
        }
        parentPawn.pawnStats.AddMana(1);
    }

    private bool AttackUpdate(List<Pawn> allPawns)
    {
        Pawn pawnToAttack = GetTarget(allPawns); ;

        if (pawnToAttack != null)
        {
            if (parentPawn.pawnStats.IsManaFull())
            {
                //activate ability
                parentPawn.pawnStats.SetCurrentMana(0);
                // parentPawn.GetPawnSO().ability.Ability(parentPawn);
                return true;
            }
        }

        pawnToAttack = GetTarget(allPawns); ;
        if (pawnToAttack != null)
        {
            if (Timer(attackTimerMax, ref attackTimerCurrent))
                return true;

            Attack(pawnToAttack);
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

        Vector2Int tileToMove;
        tileToMove = Grid.AStarNextMoveTile(parentPawn);

        if (tileToMove != null)
        {
            // moving
            // TODO make this a function
            parentPawn.combatPosition = tileToMove;
        }
        else
        {
            moveTimerCurrent = moveTimerMax;
        }
    }


    public bool Timer(float max, ref float current)
    {
        //TODO rework this for server
        //current -= Time.deltaTime;
        current -= 0.1f;
        if (current <= 0)
        {
            current = max;
            return false;
        }
        return true;
    }
}
