using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Combat
{
    static public void RunCombat()
    {
        // I need to simulate the whole combat
        // Do i just create a virtual equezilent version of the singleplayer??
        foreach(List<Player> match in MatchMaker.GetMatches())
        {
            List<Pawn> allPawns = new List<Pawn>();
            
            foreach(Player p in match) 
            {
                allPawns.AddRange(p.GetPlayerStats().GetInGamePawns());
            }

            Shuffle(allPawns);

            foreach (Pawn pawn in allPawns) 
            { 
                //update each pawn AI
            }
            
        }
    }

    static public string GetCombatResults()
    {
        return null;
    }

    public static void Shuffle<T>(IList<T> list)
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
