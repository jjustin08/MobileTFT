using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slot : MonoBehaviour
{
   private SlotInteraction slotInteraction;
   [SerializeField]private Pawn placedPawn;
   private bool hasPawn;

    private void Awake()
    {
        slotInteraction = GetComponentInChildren<SlotInteraction>();
        
    }
    public void PlacePawn(Pawn p)
    {
        if (p.GetMovement().GetSlot()!= null)
        {
            p.GetMovement().GetSlot().RemovePawn();
        }
        p.GetComponent<PawnMovement>().SetSlot(this);

        p.transform.SetParent(transform, false);
        placedPawn = p;
        

        GridUtil.Instance.UpdateMaxPawnsOnBoard();
    }

    public void RemovePawn()
    {
        placedPawn = null;
        GridUtil.Instance.UpdateMaxPawnsOnBoard();
    }
    public Pawn GetPawn()
    {
        return placedPawn;
    }

    public SlotPosition GetSlotPos()
    {
        // doesnt always have this
        return GetComponent<SlotPosition>();
    }

    public SlotInteraction GetSlotInteraction()
    {
        return slotInteraction;
    }

    public bool HasPawn()
    {
        return placedPawn != null;
    }
}
