using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAbilitySO : ScriptableObject
{
    public string description;
    virtual public void Ability(Pawn ownerPawn){ }
}
