using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Type : ScriptableObject
{
    // teired amount of pawns needed to activate this 
    public new const string name = "Default";

    public Sprite icon;


    public virtual void Effect(Pawn pawn, int amount)
    {
        //Debug.Log(name + " Amount: "+amount);
    }
}
