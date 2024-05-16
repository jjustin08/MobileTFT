using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private List<InGamePawn> pawns = new List<InGamePawn>();
    private int cash;
    private int health;
    private int level;
    private int costTolevelUp;

    public void AddPawn(PawnData PD, Vector2 pos)
    {
        pawns.Add(new InGamePawn(PD,pos,pawns.Count-1));
    }
    public List<InGamePawn> GetInGamePawns() { return pawns; }

    public void SetCash(int c)
    {
        cash = c;
    }

    public int GetCash() { return cash; }

    public void SetHealth(int h)
    {
        health = h;
    }
    public int GetHealth() { return health; }

    public void SetLevel(int level) {  this.level = level; }
    public int GetLevel() { return level; }

    public void SetCostToLevelUp(int cost)
    {
        costTolevelUp = cost;
    }
    public int GetCostToLevelUp(){return costTolevelUp;}

}


public class InGamePawn
{
    public int index;
    public PawnData pawnData;
    public Vector2 vector2;

    public InGamePawn(PawnData pwn, Vector2 vec, int index)
    {
        pawnData = pwn;
        vector2 = vec;
        this.index = index;
    }
}