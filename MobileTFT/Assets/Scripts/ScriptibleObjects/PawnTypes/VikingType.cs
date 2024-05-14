using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type", menuName = "Pawn/PawnTypes/VikingType")]
public class VikingType : TypeSO
{
    // gain gold per kill


    public int AttackPerc3 = 20;
    public int AttackPerc5 = 50;
    //public override void AffectStats(Pawn pawn, int amount)
    //{
    //    if (amount >= 5)
    //    {
    //        pawn.GetStats().SetKillCountCashBonus(AttackPerc5);
    //    }
    //    else if (amount >= 3)
    //    {
    //        pawn.GetStats().SetKillCountCashBonus(AttackPerc3);
    //    }

    //}
}
