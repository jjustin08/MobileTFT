using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type", menuName = "Types/Test")]
public class TestType : Type
{
    public new const string name = "TestType";

    public override void Effect(Pawn pawn, int amount)
    {
        base.Effect(pawn, amount);
    }
}
