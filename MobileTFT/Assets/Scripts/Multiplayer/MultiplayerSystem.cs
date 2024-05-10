using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerSystem : MonoBehaviour
{
    [SerializeField] private GameObject lobby;
    [SerializeField] private GameObject game;

    public void LoadGame()
    {
        lobby.SetActive(false);
        game.SetActive(true);
    }

}
