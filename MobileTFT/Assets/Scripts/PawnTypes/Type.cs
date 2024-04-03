using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Type : ScriptableObject
{
    // teired amount of pawns needed to activate this 
    public new const string name = "Default";


    public virtual void Effect(Pawn pawn, int amount)
    {
        //Debug.Log(name + " Amount: "+amount);
    }
}
