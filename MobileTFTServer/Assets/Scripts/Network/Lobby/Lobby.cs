using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Lobby : MonoBehaviour
{
    // I want to have max players / this will change depending on gamemode
    // I want a min players
    // a timer to wait for new players or not
    // I want a list of players and whether they are ready or not

    private List<Player> players = new List<Player>();

    private int minPlayers = 2;

    [SerializeField] private GameMode gameMode;

    private void Start()
    {
        NetworkServerProcessing.SetLobby(this);
    }

    private void CheckIfEnoughPlayers()
    {
        if (players.Count >= minPlayers)
        {
            foreach (Player player in players)
                NetworkServerProcessing.SendMessageToClient(ServerToClientSignifiers.LoadGame.ToString(), player.clientId, TransportPipeline.ReliableAndInOrder);
        }
    }

    private void CheckIfAllPlayerLoaded()
    {
        bool allPlayersReady = true;
        foreach (Player player in players)
        {
            if (player.isLoaded == false)
            {
                allPlayersReady = false;
            }
        }

        if(allPlayersReady) 
        {
            gameMode.StartGame();
           
        }
    }
    public void PlayerLeave(int clientId)
    {
        Player playerState = new Player(clientId, false);
        Player playerState2 = new Player(clientId, true);

        if(players.Contains(playerState))
        {
            players.Remove(playerState);
        }
        else if(players.Contains(playerState2))
        {
            players.Remove(playerState2);
        }

    }
    public void PlayerJoin(int clientId)
    {
        Player playerState = new Player(clientId, false);
        players.Add(playerState);
        CheckIfEnoughPlayers();
    }

    public void PlayersGameLoaded(int clientId)
    {
        // this is a mess
        Player playerState = new Player(clientId, false);
        if (players.Contains(playerState))
        {
            int index = players.IndexOf(playerState);
            playerState.isLoaded = true;
            players[index] = playerState;
        }

        CheckIfAllPlayerLoaded();
    }

    public List<Player> GetPlayers()
    {
        return players;
    }
}

public struct Player
{
    public int clientId;
    public bool isLoaded;

    // Constructor to initialize the struct
    public Player(int intValue, bool boolValue)
    {
        this.clientId = intValue;
        this.isLoaded = boolValue;
    }
}
