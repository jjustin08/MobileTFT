using System.Collections.Generic;
using UnityEngine;


static public class Lobby
{
    // I want to have max players / this will change depending on gamemode
    // I want a min players
    // a timer to wait for new players or not
    // I want a list of players and whether they are ready or not
    static private List<Player> players = new List<Player>();

    static private int minPlayers = 2;
    //static private int maxPlayers = 8;

    static private GameMode gameMode = new BasicGameMode();

    static public void RevieceMessage(string msg, int playerId)
    {
        char sepchar = ',';
        string[] csv = msg.Split(sepchar);
        int signifier = int.Parse(csv[1]);
        switch (signifier)
        {
            case LobbySignifiers.LoadGame:
                PlayersGameLoaded(playerId);
                break;
            default:
                Debug.Log("Invalid signifier");
                break;
        }
    }
    static private void CheckIfEnoughPlayers()
    {
        if (players.Count >= minPlayers)
        {
            foreach (Player player in players)
                NetworkServerProcessing.SendMessageToClient(LobbySignifiers.LoadGame.ToString(), player.getId(), TransportPipeline.ReliableAndInOrder);
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

        if (allPlayersReady)
        {
            gameMode.StartGame();

        }
    }
    static public void PlayerLeave(int clientId)
    {
        foreach (Player player in players)
        {
            if (player.getId() == clientId)
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

    static public Player GetPlayerById(int playerId)
    {
        Player templayer = null;
        foreach (Player player in players)
        {
            if (player.getId() == playerId) { templayer = player; break; }
        }
        return templayer;
    }

}


static public class LobbySignifiers
{
    public const int LoadGame = 1;
}