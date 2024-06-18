using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private List<Pawn> pawns = new List<Pawn>();
    private List<PawnData> cards = new List<PawnData>();
    private int cash;
    private int health;
    private int level;
    private int costTolevelUp;


    public List<PawnData> GetCards()
    {
        return cards;
    }

    public void SetCards(List<PawnData> cards)
    {
       this.cards = cards;
    }

    public void AddPawn(PawnData PD, Vector2Int pos, int clientID)
    {
        pawns.Add(new Pawn(PD,pos,pawns.Count-1,0));
    }
    public List<Pawn> GetInGamePawns() { return pawns; }

    public void AddCash(int c)
    {
        cash += c;
    }

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


