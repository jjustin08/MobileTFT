using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn
{
    public int index;
    public PawnData pawnData;
    public PawnStats pawnStats;
    public Vector2Int position;
    public Vector2Int combatPosition;
    public int ownerID;

    public Pawn(PawnData pwn, Vector2Int vec, int index, int ownerID)
    {
        pawnData = pwn;
        position = vec;
        combatPosition = vec;
        this.index = index;
        this.ownerID = ownerID;
        pawnStats = new PawnStats(pwn);
    }
}
