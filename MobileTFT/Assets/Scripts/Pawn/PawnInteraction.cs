using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PawnInteraction : Interaction
{
    [SerializeField] private FollowCursor followCursor;
    [SerializeField] private Pawn pawn;

    protected override void OnDrag()
    {
        if (!allowInteraction) return;

        Player.Instance.SetHoldingPawn(pawn);
        followCursor.ToggleDraggin(true);
    }

    protected override void OnDragCanceled()
    {
        if (!allowInteraction) return;

        followCursor.ToggleDraggin(false);

        GameObject hoverObject = Player.Instance.GetPlayerInput().TestCardTileIntercept();

        if(hoverObject != null)
        {
            if(hoverObject.GetComponent<SlotInteraction>() != null) 
            {
                hoverObject.GetComponent<SlotInteraction>().PawnInteraction();
            }
        }
        else
        {
            Player.Instance.SetHoldingPawn(null);
        }
       
    }

}
