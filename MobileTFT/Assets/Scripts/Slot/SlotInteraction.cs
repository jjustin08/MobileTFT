using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotInteraction : Interaction
{
    [SerializeField] private Slot tile;

    public void PawnInteraction()
    {
        if (!allowInteraction) return;


        Pawn tempPawn = Player.Instance.GetHoldingPawn();
        if (tempPawn != null)
        {
            if (tempPawn.GetMovement().GetSlot() != null)
            {
                tempPawn.GetMovement().GetSlot().RemovePawn();
            }
        }
        

        if (tile.GetComponent<SlotPosition>() != null)
        {
            if (Player.Instance.GetPlayerStats().IsPawnAmountFull()) return;
        }


        if (tempPawn != null)
        {
            tile.PlacePawn(tempPawn);
            Player.Instance.SetHoldingPawn(null);
        }
    }
}
