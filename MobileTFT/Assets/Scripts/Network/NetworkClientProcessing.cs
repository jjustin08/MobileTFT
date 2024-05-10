using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class NetworkClientProcessing
{
    #region Send and Receive Data Functions
    static public void ReceivedMessageFromServer(string msg, TransportPipeline pipeline)
    {
        Debug.Log("Network msg received =  " + msg + ", from pipeline = " + pipeline);

        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[0]);

        switch (signifier)
        {
            case ServerToClientSignifiers.LoadGame:
                lobby.LoadGame();
                break; 
            case ServerToClientSignifiers.Gamemode:
                gamemode.RecieveServerMsg(msg);
                break;
            case 0:
               // Debug.Log("All good");
                break;
            default:
                Debug.Log("Invalid signifier");
                break;
        }
    }

    static public void SendMessageToServer(string msg, TransportPipeline pipeline)
    {
        networkClient.SendMessageToServer(msg, pipeline);
    }

    #endregion

    #region Connection Related Functions and Events
    static public void ConnectionEvent()
    {
        Debug.Log("Network Connection Event!");
    }
    static public void DisconnectionEvent()
    {
        Debug.Log("Network Disconnection Event!");
    }
    static public bool IsConnectedToServer()
    {
        return networkClient.IsConnected();
    }
    static public void ConnectToServer()
    {
        networkClient.Connect();
    }
    static public void DisconnectFromServer()
    {
        networkClient.Disconnect();
    }

    #endregion

    #region Setup
    static NetworkClient networkClient;

    static public void SetNetworkedClient(NetworkClient NetworkClient)
    {
        networkClient = NetworkClient;
    }
    static public NetworkClient GetNetworkedClient()
    {
        return networkClient;
    }

    static Lobby lobby;
    static public void SetLobby(Lobby lob)
    {
        lobby = lob;
    }

    static GameMode gamemode;

    static public void SetGameMode(GameMode gm)
    {
        gamemode = gm;
    }

    #endregion

}

#region Protocol Signifiers
static public class ClientToServerSignifiers
{
    public const int JoinLobby = 1;
    public const int GameLoaded = 2;
}

static public class ServerToClientSignifiers
{
    public const int LoadGame = 1;
    public const int Gamemode = 2;
}


#endregion
