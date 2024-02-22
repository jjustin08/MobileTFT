using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnInteraction : Interaction
{
    [SerializeField] private FollowCursor followCursor;

    protected override void OnDrag()
    {
        followCursor.ToggleDraggin(true);
    }

    protected override void OnDragCanceled()
    {
        followCursor.ToggleDraggin(false);
    }
}
