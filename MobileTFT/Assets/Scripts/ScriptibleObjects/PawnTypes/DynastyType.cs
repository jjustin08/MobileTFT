using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type", menuName = "Types/DynastyType")]
public class DynastyType : TypeSO
{
    public float AttackTimePerc3 = 1.0f;
    public float AttackTimePerc5 = 1.5f;

    public override void AffectStats(Pawn pawn, int amount)
    {
        if (amount >= 5)
        {
            pawn.GetStats().SetKillCountDamageModifier(AttackTimePerc5);
        }
        else if (amount >= 3)
        {
            pawn.GetStats().SetKillCountDamageModifier(AttackTimePerc3);
        }
    }
}
