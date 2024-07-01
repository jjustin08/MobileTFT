using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

static public class MatchMaker
{
    static private List<Match> matches;

    static public List<Match> GetMatches(){ return matches; }
    static public void MatchMake()
    {
        List<Player> availablePlayers = Lobby.GetPlayers();
        int lastPlayerIndex = availablePlayers.Count - 1;

        if (availablePlayers.Count < 2)
        {
            Debug.Log("Not enough players to create a match.");
            return;
        }

        // Create a list to hold the matches
        matches = new List<Match>();

        // Loop through the available players and create pairs
        for (int i = 0; i <= lastPlayerIndex; i += 2)
        {
            if (i + 1 <= lastPlayerIndex) // Check if there's a player to pair with
            {
                Match match = new Match(availablePlayers[i], availablePlayers[i + 1]);
                matches.Add(match);
            }
            else
            {
                // If there's an odd number of players, the last player will be without a match
            }
        }
    }


    static public string GetShuffledPawnList(Player player)
    {
        string msg = "";

        foreach (Match m in matches)
        {
            List<Player> mPlayers = m.GetPlayers();
            if (mPlayers.Contains(player))
            {
                foreach (Player p in mPlayers) 
                {
                    int friendly = 0;
                    if(p == player)
                    {
                        friendly = 1;
                    }
                    else 
                    {
                        friendly = 0;
                    }
                    for(int i = 0; i < p.GetPlayerStats().GetInGamePawns().Count; i++)
                    {
                        msg += friendly + "," + i + "," + m.GetAllPawns().IndexOf(p.GetPlayerStats().GetInGamePawns()[i]) + ",";
                    }                
                }
               
            }
            

            
        }

        return msg;
    }

        static public string GetOppenonts(Player player)
        {
            Player opponent = null;
            foreach (Match m in matches)
            {
                List<Player> mPlayers = m.GetPlayers();
                if (mPlayers.Contains(player))
                {

                    if (mPlayers[0] == player)
                    {
                        opponent = mPlayers[1];
                    }
                    else
                    {
                        opponent = mPlayers[0];
                    }
                    break;
                }
            }

            string message = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.EndTurn;

            if (opponent != null)
            {
                foreach (Pawn p in opponent.GetPlayerStats().GetInGamePawns())
                {
                    if (p.position.x == -1)
                        continue;
                    //TODO add extra pawn data here
                    Vector2 convertedPos = new Vector2(5 - p.position.x, 7 - p.position.y);

                    message += "," + p.pawnData.index + "," + convertedPos.x + "," + convertedPos.y;
                }
            }
        message += ",;,";
        message += GetShuffledPawnList(player);

            return message;
        }
}
