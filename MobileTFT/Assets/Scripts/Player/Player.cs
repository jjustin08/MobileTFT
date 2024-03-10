using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private Pawn holdingPawn;
    [SerializeField] private PlayerInput playerInput;

    public PlayerInput GetPlayerInput() { return playerInput; }

    private void Awake()
    {
        Instance = this;
    }



    public void SetHoldingPawn(Pawn Pawn) { holdingPawn = Pawn; }
    public Pawn GetHoldingPawn() { return holdingPawn; }
}
