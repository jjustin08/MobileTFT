using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type", menuName = "Pawn/PawnTypes/UndeadType")]
public class UndeadType : TypeSO
{
    // special ability does not die\
    // also gains something every time they die

    public int deathBonusPerc2 = 1;
    public int deathBonusPerc4 = 2;

    //public override void AffectStats(Pawn pawn, int amount)
    //{
    //    int deathCount = pawn.GetStats().GetDeathCount();

    //    if (amount >= 4)
    //    {
    //        pawn.GetStats().SetKillCount(pawn.GetStats().GetKillCount() + (deathCount * deathBonusPerc4));
    //    }
    //    else if (amount >= 2)
    //    {
    //        pawn.GetStats().SetKillCount(pawn.GetStats().GetKillCount() + (deathCount * deathBonusPerc2));
    //    }
    //}
}
