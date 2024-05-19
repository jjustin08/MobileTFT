using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Type", menuName = "Types/TankType")]
public class TankType : TypeSO
{
    public float HealthPerc2 = 1.3f;
    public float HealthPerc4 = 1.6f;
    public float HealthPerc6 = 2.0f;

    public override void AffectStats(Pawn pawn, int amount)
    {
        if(amount >= 6) 
        {
            pawn.GetStats().SetCurrentHealth(pawn.GetStats().GetCurrentHealth() * HealthPerc6);
        }
        else if(amount >= 4) 
        {
            pawn.GetStats().SetCurrentHealth(pawn.GetStats().GetCurrentHealth() * HealthPerc4);
        }
        else if (amount >= 2)
        {
            pawn.GetStats().SetCurrentHealth(pawn.GetStats().GetCurrentHealth() * HealthPerc2);
        }

        
 }
}
