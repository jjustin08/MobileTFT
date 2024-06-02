using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn
{
    public int index;
    public PawnData pawnData;
    public Vector2 position;
    public int ownerID;

    public Pawn(PawnData pwn, Vector2 vec, int index, int ownerID)
    {
        pawnData = pwn;
        position = vec;
        this.index = index;
        this.ownerID = ownerID;
    }
}
