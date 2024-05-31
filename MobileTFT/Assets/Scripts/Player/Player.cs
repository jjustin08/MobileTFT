using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private Pawn holdingPawn;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerStats playerStats;

    public PlayerInput GetPlayerInput() { return playerInput; }

    private void Awake()
    {
        Instance = this;
        playerStats = GetComponent<PlayerStats>();
    }

    public PlayerStats GetPlayerStats() { return playerStats; }

    public void SetHoldingPawn(Pawn Pawn) { holdingPawn = Pawn; }
    public Pawn GetHoldingPawn() { return holdingPawn; }
}
static public class PlayerSignifiers
{
    public const int BuyPawn = 1;
    public const int MovePawn = 2;
    public const int SellPawn = 3;
}