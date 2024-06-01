using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class MatchMaker
{
    static private List<List<Player>> matches;
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
        matches = new List<List<Player>>();

        // Loop through the available players and create pairs
        for (int i = 0; i <= lastPlayerIndex; i += 2)
        {
            if (i + 1 <= lastPlayerIndex) // Check if there's a player to pair with
            {
                List<Player> match = new List<Player> { availablePlayers[i], availablePlayers[i + 1] };
                matches.Add(match);
            }
            else
            {
                // If there's an odd number of players, the last player will be without a match
            }
        }
    }

   static public string GetOppenonts(Player player)
   {
        Player opponent = null;
        foreach (List<Player> players in matches) 
        { 
            if(players.Contains(player))
            {
                
                if(players[0] == player)
                {
                    opponent = players[1];
                }
                else
                {
                    opponent = players[0];
                }
                continue;
            }
        }

        string message = ServerToClientSignifiers.Gamemode + "," + GameModeSignifiers.EndTurn + ",";

        if( opponent != null )
        {
            foreach(Pawn p in opponent.GetPlayerStats().GetInGamePawns())
            {
 
                //TODO add extra pawn data here
                Vector2 convertedPos = new Vector2(5 - p.position.x, 7 - p.position.y);
                
                message += p.pawnData.index + "," + convertedPos.x + "," + convertedPos.y;
            }
        }
       
        return message;
    }


}
