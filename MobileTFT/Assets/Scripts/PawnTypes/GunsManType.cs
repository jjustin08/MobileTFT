using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type", menuName = "Types/GunsManType")]
public class GunsManType : Type
{
    public float AttackTimePerc2 = 0.8f;
    public float AttackTimePerc4 = 0.6f;

    public override void AffectStats(Pawn pawn, int amount)
    {
        if (amount >= 4)
        {
            pawn.GetStats().SetDamageTime(pawn.GetStats().GetAttackTime() * AttackTimePerc4);
        }
        else if (amount >= 2)
        {
            pawn.GetStats().SetDamageTime(pawn.GetStats().GetAttackTime() * AttackTimePerc2);
        }
    }
}
