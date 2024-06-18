using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEditor.MemoryProfiler;
using UnityEditor.VersionControl;
using UnityEngine;


static public class NetworkServerProcessing
{
    public const char sepchar = ',';
    #region Send and Receive Data Functions
    static public void ReceivedMessageFromClient(string msg, int clientConnectionID, TransportPipeline pipeline)
    {
        Debug.Log("Network msg received =  " + msg + ", from connection id = " + clientConnectionID + ", from pipeline = " + pipeline);

        string[] csv = msg.Split(sepchar);
        int signifier = int.Parse(csv[0]);

        switch (signifier)
        {
            case ClientToServerSignifiers.Lobby:
                Lobby.RevieceMessage(msg, clientConnectionID);
                break;
            case ClientToServerSignifiers.CardManager:
                CardManager.RecieveMessage(msg, clientConnectionID);
                break;
            case ClientToServerSignifiers.Player:
                Lobby.GetPlayerById(clientConnectionID).RevieceMessage(msg);
                break;
            default:
                Debug.Log("Invalid signifier");
                break;
        }
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
        Lobby.PlayerJoin(clientConnectionID);
        Debug.Log("Client connection, ID == " + clientConnectionID);
    }
    static public void DisconnectionEvent(int clientConnectionID)
    {
        //LobbyManager.Instance.LeaveLobby(clientConnectionID);
        //clientManager.RemoveUser(clientConnectionID);
        // remove from lobbies
        Lobby.PlayerLeave(clientConnectionID);
        Debug.Log("Client disconnection, ID == " + clientConnectionID);
    }

    #endregion

    #region Setup
    static NetworkServer networkServer;
    
    //static ClientManager clientManager;
   

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


    #endregion
}

#region Protocol Signifiers


static public class ClientToServerSignifiers
{
    public const int Lobby = 1;
    public const int CardManager = 2;
    public const int Player = 3;
}

static public class ServerToClientSignifiers
{
    public const int Lobby = 1;
    public const int CardManager = 2;
    public const int Player = 3;
    public const int Gamemode = 4;
}



#endregion
