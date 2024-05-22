using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEditor.Experimental.GraphView.GraphView;

static public class Lobby
{
    // I want to have max players / this will change depending on gamemode
    // I want a min players
    // a timer to wait for new players or not
    // I want a list of players and whether they are ready or not
    static private List<Player> players = new List<Player>();

    static private int minPlayers = 2;
    static private int maxPlayers = 8;

    static private GameMode gameMode = new BasicGameMode();

    static private void CheckIfEnoughPlayers()
    {
        if (players.Count >= minPlayers)
        {
            foreach (Player player in players)
                NetworkServerProcessing.SendMessageToClient(ServerToClientSignifiers.LoadGame.ToString(), player.getId(), TransportPipeline.ReliableAndInOrder);
        }
    }

    static private void CheckIfAllPlayerLoaded()
    {
        bool allPlayersReady = true;
        foreach (Player player in players)
        {
            if (!player.IsLoaded())
            {
                allPlayersReady = false;
            }
        }

        if(allPlayersReady) 
        {
            gameMode.StartGame();
           
        }
    }
    static public void PlayerLeave(int clientId)
    {
        foreach (Player player in players)
        {
            if(player.getId() == clientId)
            {
                players.Remove(player);
            }
        }
    }
    static public void PlayerJoin(int clientId)
    {
        players.Add(new Player(clientId));
        CheckIfEnoughPlayers();
    }

    static public void PlayersGameLoaded(int clientId)
    {
        foreach (Player player in players)
        {
            if (player.getId() == clientId)
            {
                player.SetIsLoaded(true);
            }
        }
        CheckIfAllPlayerLoaded();
    }

    static public List<Player> GetPlayers()
    {
        return players;
    }
}
