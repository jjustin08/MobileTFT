using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachineTriggerAction.ActionSettings;

public class Lobby : MonoBehaviour
{
    [SerializeField] private MultiplayerSystem multiplayerSystem;

    void Start()
    {
        NetworkClientProcessing.SetLobby(this);
    }


    public void RevieceMessage(string msg)
    {

        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[0]);

        switch (signifier)
        {
            case LobbySignifiers.LoadGame:
                LoadGame();
                break;
            default:
                Debug.Log("Invalid signifier");
                break;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            string msg = ClientToServerSignifiers.Lobby + "," + LobbySignifiers.LoadGame;
            NetworkClientProcessing.SendMessageToServer(msg, TransportPipeline.ReliableAndInOrder);
        }
    }
    public void LoadGame()
    {
        multiplayerSystem.LoadGame();
    }

}

static public class LobbySignifiers
{
    public const int LoadGame = 1;
}
