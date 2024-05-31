using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private int connectionId;
    private bool isLoaded;
    private PlayerStats stats = new PlayerStats();
    public Player(int connectionId)
    {
        this.connectionId = connectionId;
    }

    public PlayerStats GetPlayerStats() { return stats; }
    public int getId() { return connectionId; }
    public bool IsLoaded() { return isLoaded; }

    public void SetIsLoaded(bool toggle)
    {
        isLoaded = toggle;
    }

    public void RevieceMessage(string msg)
    {
        //TODO add checks
        char sepchar = ',';
        string[] csv = msg.Split(sepchar);
        int signifier = int.Parse(csv[1]);

        switch (signifier)
        {
            case PlayerSignifiers.BuyPawn:
                stats.AddPawn(PawnDataBase.pawns[int.Parse(csv[2])], new Vector2(int.Parse(csv[3]), int.Parse(csv[4])));
                break;
            case PlayerSignifiers.MovePawn:
                Pawn tempPawn = stats.GetInGamePawns()[int.Parse(csv[2])];
                tempPawn.position = new Vector2(int.Parse(csv[3]), int.Parse(csv[4]));
                break;
            case PlayerSignifiers.SellPawn:
                PawnData tempPData = stats.GetInGamePawns()[int.Parse(csv[2])].pawnData;
                stats.GetInGamePawns().RemoveAt(int.Parse(csv[2]));
                stats.AddCash(tempPData.cost);
                break;
            default:
                Debug.Log("Invalid signifier");
                break;
        }
    }
}




static public class PlayerSignifiers
{
    public const int BuyPawn = 1;
    public const int MovePawn = 2;
    public const int SellPawn = 3;
}
