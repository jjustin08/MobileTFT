using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class Match
{
    //PLayers
    //players contain there pawns etc
    private List<Player> players = new List<Player>();
    public Match(Player player1, Player player2)
    {
        players.Add(player1);
        players.Add(player2);


        allPawns.AddRange(player1.GetPlayerStats().GetInGamePawns());
        allPawns.AddRange(player2.GetPlayerStats().GetInGamePawns());

        Shuffle(allPawns);

        foreach (Pawn pawn in allPawns)
        {
            pawn.InitPawnAI();
        }
    }
    public List<Player> GetPlayers()
    {
        return players;
    }

    public bool ContainsPlayerID(int clientID)
    {
        foreach (Player p in players)
        {
            if(p.getId() == clientID) return true;
        }

        return false;
    }
    // Match results
    // who won
    // how many pawns left and which ones
    // TODO: Pawn stats? killcount? 

    private int winnerID;
    private List<Pawn> alivePawns = new List<Pawn>();

    public void SetMatchResults(int winnerID, List<Pawn> alivePawns)
    {
        this.winnerID = winnerID;
        this.alivePawns = alivePawns;
    }

    public string GetMatchResults()
    {
        string results = null;
        results = winnerID + "";
        if (players[0].getId() == winnerID)
        {
            int newPlayerhealth = players[1].GetPlayerStats().GetHealth() - alivePawns.Count; 
            players[1].GetPlayerStats().SetHealth(newPlayerhealth);
            foreach (Pawn p in alivePawns)
            {
                results += "," + players[0].GetPlayerStats().GetInGamePawns().IndexOf(p);
            }
        }
        else if(players[1].getId() == winnerID)
        {
            int newPlayerhealth = players[0].GetPlayerStats().GetHealth() - alivePawns.Count;
            players[0].GetPlayerStats().SetHealth(newPlayerhealth);
            foreach (Pawn p in alivePawns)
            {
                results += "," + players[1].GetPlayerStats().GetInGamePawns().IndexOf(p);
            }
            
        }
       
        return results;
    }


    // things

    List<Pawn> allPawns = new List<Pawn>();

    public List<Pawn> GetAllPawns()
    {
        return allPawns;
    }
    public void Shuffle<T>(IList<T> list)
    {
        System.Random rng = new System.Random();

        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}
