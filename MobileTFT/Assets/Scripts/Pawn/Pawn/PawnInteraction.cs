using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PawnInteraction : Interaction
{
    [SerializeField] private FollowCursor followCursor;
    [SerializeField] private Pawn parentPawn;

    protected override void OnDrag()
    {
        if (!allowInteraction) return;

        Player.Instance.SetHoldingPawn(parentPawn);
        followCursor.ToggleDraggin(true);

        GameObject hoverObject = Player.Instance.GetPlayerInput().TestCardTileIntercept();

        if (hoverObject != null)
        {
            if (hoverObject.GetComponent<SlotInteraction>() != null)
            {
                hoverObject.GetComponentInParent<SlotVisual>().ToggleSelect(true);
            }
        }
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
            if(hoverObject.GetComponent<SellInteraction>() != null)
            {
                hoverObject.GetComponent<SellInteraction>().RequestSellPawn(parentPawn, parentPawn.GetStats().GetStarCount());
            }
        }

        Player.Instance.SetHoldingPawn(null);
    }

    protected override void OnClick()
    {
        PawnInfoUI.Instance.ToggleUI();
        PawnInfoUI.Instance.UpdateUI(parentPawn.GetStats());
    }


    public void CancelDrag()
    {
        followCursor.ToggleDraggin(false);
        Player.Instance.SetHoldingPawn(null);
    }
}
