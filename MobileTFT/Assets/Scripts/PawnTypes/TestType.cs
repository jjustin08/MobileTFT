using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type", menuName = "Types/Test")]
public class TestType : Type
{
    public override void AffectStats(Pawn pawn, int amount)
    {
        base.AffectStats(pawn, amount);
    }
}
