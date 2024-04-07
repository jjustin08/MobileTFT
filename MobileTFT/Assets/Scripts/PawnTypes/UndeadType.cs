using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type", menuName = "Types/UndeadType")]
public class UndeadType : Type
{
    // special ability does not die\
    // also gains something every time they die

    public float deathBonusPerc2 = 1.0f;
    public float deathBonusPerc4 = 2.0f;

    public override void AffectStats(Pawn pawn, int amount)
    {
        int deathCount = pawn.GetStats().GetDeathCount();

        if (amount >= 4)
        {
            pawn.GetStats().SetDamage(pawn.GetStats().GetDamage() + (deathCount * deathBonusPerc4));
        }
        else if (amount >= 2)
        {
            pawn.GetStats().SetDamage(pawn.GetStats().GetDamage() + (deathCount * deathBonusPerc2));
        }
    }
}
