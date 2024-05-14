using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Pawn/PawnAbility")]
public class BasicAbilitySO : PawnAbilitySO
{
    public override void Ability(Pawn ownerPawn)
    {
        SlotPosition target = ownerPawn.GetAI().GetTarget();
        ownerPawn.GetAI().Attack(target);

    }
}
