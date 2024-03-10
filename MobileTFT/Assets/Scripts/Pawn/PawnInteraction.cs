using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnInteraction : Interaction
{
    [SerializeField] private FollowCursor followCursor;
    [SerializeField] private Pawn pawn;

    protected override void OnDrag()
    {
        Player.Instance.SetHoldingPawn(pawn);
        followCursor.ToggleDraggin(true);
    }

    protected override void OnDragCanceled()
    {
        
        followCursor.ToggleDraggin(false);

        GameObject hoverObject = Player.Instance.GetPlayerInput().TestCardTileIntercept();

        if(hoverObject != null)
        {
            if(hoverObject.GetComponent<TileInteraction>() != null) 
            {
                hoverObject.GetComponent<TileInteraction>().PawnInteraction();
            }
        }
        else
        {
            Player.Instance.SetHoldingPawn(null);
        }
       
    }
}
