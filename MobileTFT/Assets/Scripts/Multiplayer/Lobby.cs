using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    [SerializeField] private MultiplayerSystem multiplayerSystem;

    void Start()
    {
        NetworkClientProcessing.SetLobby(this);
 }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            NetworkClientProcessing.SendMessageToServer(ClientToServerSignifiers.JoinLobby.ToString(), TransportPipeline.ReliableAndInOrder);
        }
    }
    public void LoadGame()
    {
        multiplayerSystem.LoadGame();
    }

}
