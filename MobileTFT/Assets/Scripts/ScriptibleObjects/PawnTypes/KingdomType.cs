using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Type", menuName = "Types/KingdomType")]
public class KingdomType : TypeSO
{
    //more gold the more stats

    public float AttackPerc2 = 1.05f;
    public float AttackPerc4 = 1.1f;
    public float AttackPerc6 = 1.15f;

    public override void AffectStats(Pawn pawn, int amount)
    {
        int gold = Player.Instance.GetPlayerStats().GetCash();
        if (amount >= 6)
        {
            for (int i = 10; i <= gold && i <= 50; i +=10)
            pawn.GetStats().SetDamage(pawn.GetStats().GetDamage() * AttackPerc6);
        }
        else if (amount >= 4)
        {
            for (int i = 10; i <= gold && i <=50; i += 10)
                pawn.GetStats().SetDamage(pawn.GetStats().GetDamage() * AttackPerc4);
        }
        else if (amount >= 2)
        {
            for (int i = 10; i <= gold && i <= 50; i += 10)
                pawn.GetStats().SetDamage(pawn.GetStats().GetDamage() * AttackPerc2);
        }
    }
}
