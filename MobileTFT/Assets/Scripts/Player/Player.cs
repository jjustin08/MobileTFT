using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    private GameObject holdingPawn;
    [SerializeField] private PlayerInput playerInput;

    public PlayerInput GetPlayerInput() { return playerInput; }

    private void Awake()
    {
        Instance = this;
    }



    public void SetHoldingPawn(GameObject Pawn) { holdingPawn = Pawn; }
    public GameObject GetHoldingPawn() { return holdingPawn; }
}
