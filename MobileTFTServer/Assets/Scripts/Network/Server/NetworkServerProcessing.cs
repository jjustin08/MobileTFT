using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.MemoryProfiler;
using UnityEditor.VersionControl;
using UnityEngine;


static public class NetworkServerProcessing
{

    #region Send and Receive Data Functions
    static public void ReceivedMessageFromClient(string msg, int clientConnectionID, TransportPipeline pipeline)
    {
        Debug.Log("Network msg received =  " + msg + ", from connection id = " + clientConnectionID + ", from pipeline = " + pipeline);

        string[] csv = msg.Split(sepchar);
        int signifier = int.Parse(csv[0]);


        string returnMessage = "0";

        switch (signifier)
        {
            case ClientToServerSignifiers.JoinLobby:
                lobby.PlayerJoin(clientConnectionID);
                
                break;
            case ClientToServerSignifiers.GameLoaded:
                lobby.PlayersGameLoaded(clientConnectionID);
                break;

            default:
                Debug.Log("Invalid signifier");
                break;
        }

        SendMessageToClient(returnMessage, clientConnectionID, TransportPipeline.ReliableAndInOrder);
    }
    static public void SendMessageToClient(string msg, int clientConnectionID, TransportPipeline pipeline)
    {
        networkServer.SendMessageToClient(msg, clientConnectionID, pipeline);
    }

    #endregion

    #region Connection Events

    static public void ConnectionEvent(int clientConnectionID)
    {
        //clientManager.AddUser(clientConnectionID);
        Debug.Log("Client connection, ID == " + clientConnectionID);
    }
    static public void DisconnectionEvent(int clientConnectionID)
    {
        //LobbyManager.Instance.LeaveLobby(clientConnectionID);
        //clientManager.RemoveUser(clientConnectionID);
        // remove from lobbies
        Debug.Log("Client disconnection, ID == " + clientConnectionID);
    }

    #endregion

    #region Setup
    static NetworkServer networkServer;
    static Lobby lobby;
    //static ClientManager clientManager;
    private const char sepchar = ',';

    //static public void SetClientManager(ClientManager manager)
    //{
    //    clientManager = manager;
    //}
    static public void SetNetworkServer(NetworkServer NetworkServer)
    {
        networkServer = NetworkServer;
    }
    static public NetworkServer GetNetworkServer()
    {
        return networkServer;
    }


    static public void SetLobby(Lobby newLobby)
    {
        lobby = newLobby;
    }

    static public Lobby GetLobby() { return lobby; }

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
