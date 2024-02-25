using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteraction : Interaction
{
    [SerializeField] private Slot tile;

    protected override void OnDragCanceled()
    {
        
    }

    public void PawnInteraction()
    {
        GameObject tempPawn = Player.Instance.GetHoldingPawn();
        if (tempPawn != null)
        {
            tile.PlacePawn(tempPawn);
            Player.Instance.SetHoldingPawn(null);
        }
    }
}
