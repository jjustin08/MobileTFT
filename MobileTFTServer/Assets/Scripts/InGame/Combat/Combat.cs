using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Combat
{

    static public List<Pawn> allPawns;
    static public void RunCombat()
    {
        
        // I need to simulate the whole combat
        // Do i just create a virtual equezilent version of the singleplayer??
        foreach(List<Player> match in MatchMaker.GetMatches())
        {
            allPawns = new List<Pawn>();
            
            foreach(Player p in match) 
            {
                allPawns.AddRange(p.GetPlayerStats().GetInGamePawns());
            }

            Shuffle(allPawns);

            foreach (Pawn pawn in allPawns) 
            { 
                pawn.InitPawnAI();
            }

            while (CombatUpdate(allPawns))
            {

            }
            Debug.Log("Combat is over!!!!!!!!!!!!!");
        }
    }

    static public bool CombatUpdate(List<Pawn> allPawns)
    {
        foreach (Pawn pawn in allPawns)
        {
            pawn.pawnAI.AIUpdate(allPawns);
        }

        if(!IsCombatOver(allPawns))
        {
            return false;
        }

        return true;
    }

    static private bool IsCombatOver(List<Pawn> allPawns)
    {
        int playerID = 0;
        bool counterIndex = false;
        int aliveOne = 0;
        int aliveTwo = 0;
        foreach (Pawn pawn in allPawns)
        {

            if (playerID != pawn.ownerID)
            {
                counterIndex = !counterIndex;
                playerID = pawn.ownerID;
            }
            if (counterIndex)
            {
                if (pawn.pawnStats.GetHealth() > 0)
                    aliveOne++;
            }
            else
            {
                if (pawn.pawnStats.GetHealth() > 0)
                    aliveTwo++;
            }
        }
        if (aliveOne == 0 || aliveTwo == 0)
        {
            return false;
        }

        return true;
    }

    static public string GetCombatResults()
    {
        //TODO properly send results
        string resultsMsg = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.EndCombat + ",";
        return resultsMsg;
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

    public static void KillPawn(Pawn pawnToKill)
    {
        allPawns.Remove(pawnToKill);
    }
}
