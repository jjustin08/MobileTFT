using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public int index;
    public PawnData pawnData;
    public Vector2 position;

    public Pawn(PawnData pwn, Vector2 vec, int index)
    {
        pawnData = pwn;
        position = vec;
        this.index = index;
    }
}
