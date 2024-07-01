using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Combat
{
    static private Match currentMatch = null;

    static public Match GetCurrentMatch()
    {
          return currentMatch;
    }
    static public void RunCombat()
    {
        foreach(Match match in MatchMaker.GetMatches())
        {
            currentMatch = match;
            while (CombatUpdate(match))
            {

            }

            Debug.Log("Combat is over!!!!!!!!!!!!!");
        }
    }

    static public bool CombatUpdate(Match match)
    {

        foreach (Pawn pawn in match.GetAllPawns())
        {
            if(pawn.pawnStats.GetHealth() > 0) 
            {
                pawn.pawnAI.AIUpdate();
            }
            
        }

        if(!IsCombatOver(match))
        {
            return false;
        }

        return true;
    }

    static private bool IsCombatOver(Match match)
    {
        int playerID = 0;
        bool counterIndex = false;
        List<Pawn> aliveOne = new List<Pawn>();
        List<Pawn> aliveTwo = new List<Pawn>();
        foreach (Pawn pawn in match.GetAllPawns())
        {

            if (playerID != pawn.ownerID)
            {
                counterIndex = !counterIndex;
                playerID = pawn.ownerID;
            }
            if (counterIndex)
            {
                if (pawn.pawnStats.GetHealth() > 0)
                    aliveOne.Add(pawn);
            }
            else
            {
                if (pawn.pawnStats.GetHealth() > 0)
                    aliveTwo.Add(pawn);
            }
        }
        if (aliveOne.Count == 0 || aliveTwo.Count == 0)
        {
            if(aliveOne.Count == 0) 
            {
                match.SetMatchResults(aliveTwo[0].ownerID,aliveTwo);
            }
            else if (aliveTwo.Count == 0) 
            {
                match.SetMatchResults(aliveOne[0].ownerID,aliveOne);
            }
                     
            return false;
        }

        return true;
    }

    static public string GetCombatResults(int clientID)
    {
        string resultsMsg = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.EndCombat;
        foreach (Match m in MatchMaker.GetMatches())
        {
            if(m.ContainsPlayerID(clientID))
            {
                resultsMsg += "," + m.GetMatchResults();
                break;
            }
        }
        return resultsMsg;
    }

}
