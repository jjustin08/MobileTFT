using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type", menuName = "Types/GoblinType")]
public class GoblinType : Type
{
    // make them move faster

    public float moveTimePerc3 = 0.8f;
    public float moveTimePerc5 = 0.5f;

    public override void AffectStats(Pawn pawn, int amount)
    {
        if (amount >= 5)
        {
            pawn.GetStats().SetMoveTime(moveTimePerc5);
        }
        else if (amount >= 3)
        {
            pawn.GetStats().SetMoveTime(moveTimePerc3);
        }
    }
}
