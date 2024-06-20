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



    public void RecieveMessage(string msg)
    {
        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[1]);

        switch (signifier)
        {
            case PlayerSignifiers.MovePawn:

                break;
            case PlayerSignifiers.SellPawn:
                Pawn p = playerStats.GetPawnList()[int.Parse(csv[2])];
                p.GetMovement().GetSlot().RemovePawn();
                playerStats.GetPawnList().Remove(p);
                Destroy(p.gameObject);
                break;
            default:
                Debug.Log("Invalid signifier");
                break;
        }
    }

    

}
static public class PlayerSignifiers
{
    public const int MovePawn = 1;
    public const int SellPawn = 2;
    public const int levelUp = 3;
}