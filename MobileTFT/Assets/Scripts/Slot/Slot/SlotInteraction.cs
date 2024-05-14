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
        Slot oldSlot = tempPawn.GetMovement().GetSlot();
        if (tempPawn != null)
        {
            if (oldSlot != null)
            {
                oldSlot.RemovePawn();
            }
        }
        if (tile.HasPawn())
        {
            // switch pawns spots
            
            oldSlot.PlacePawn(tile.GetPawn());
            tempPawn.GetMovement().SetSlot(null);
            tile.PlacePawn(tempPawn);
            Player.Instance.SetHoldingPawn(null);
            return;
        }
        if (tile.GetComponent<SlotPosition>() != null)
        {
            if (Player.Instance.GetPlayerStats().IsPawnAmountFull())
            {
               
                oldSlot.PlacePawn(tempPawn);
                Player.Instance.SetHoldingPawn(null);
                HelperUI.Instance.ActivateHelperText("Board Is Full");
                return;

            }

        }
        if (tempPawn != null)
        {
            tile.PlacePawn(tempPawn);
            Player.Instance.SetHoldingPawn(null);
        }

       
    }
}
