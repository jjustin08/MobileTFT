using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type : ScriptableObject
{
    // teired amount of pawns needed to activate this 
    public string typeName = "Default";

    public string description = "Default";

    public Sprite icon;


    public virtual void AffectStats(Pawn pawn, int amount)
    {
        //Debug.Log(name + " Amount: "+amount);
    }
}
