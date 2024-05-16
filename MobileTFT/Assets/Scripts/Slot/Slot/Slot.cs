using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slot : MonoBehaviour
{
   private SlotInteraction slotInteraction;
   [SerializeField]private Pawn placedPawn;

    public event EventHandler OnPawnChange;

    private void Awake()
    {
        slotInteraction = GetComponentInChildren<SlotInteraction>();
    }
    public void PlacePawn(Pawn p)
    {
        Slot oldSlot = null;
        Transform newSlot = transform;
        

        if (p.GetMovement().GetSlot()!= null)
        {
            oldSlot = p.GetMovement().GetSlot();
            p.GetMovement().GetSlot().RemovePawn();
        }
        p.GetComponent<PawnMovement>().SetSlot(this);

        //move this somewhere else
        if(oldSlot != null && GridUtil.Instance.GetAllSlots().Contains(oldSlot) && GridUtil.Instance.GetAllSlots().Contains(this) && GridUtil.Instance.GetInCombat()) 
        {
            LerpingMovement lerpingMovement = p.gameObject.AddComponent<LerpingMovement>();
            lerpingMovement.oldPosition = oldSlot.transform;
            lerpingMovement.newPosition = newSlot;
            lerpingMovement.obj = p.transform;
        }
        else
        {
            p.transform.SetParent(transform, false);
        }
        placedPawn = p;
        
        OnPawnChange?.Invoke(this, EventArgs.Empty);
    }

    public void RemovePawn()
    {
        placedPawn = null;
       
        OnPawnChange?.Invoke(this, EventArgs.Empty);
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
