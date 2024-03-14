using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PawnStorage : MonoBehaviour
{
    private List<Slot> slots = new List<Slot>();

    public PawnSO tempPawnSO;
    void Start()
    {
        slots.AddRange(GetComponentsInChildren<Slot>());
    }
    private void Update()
    {
        // debug input
        if(Input.GetKeyDown(KeyCode.E))
        {
            FillSlot(tempPawnSO);
        }
    }

    public bool FillSlot(PawnSO SO)
    {
        foreach (Slot slot in slots) 
        { 
            if(!slot.HasPawn())
            {
                Pawn newPawn = Instantiate(SO.placedPawn);
                newPawn.SetPawnSO(SO);
                slot.PlacePawn(newPawn);
                return true;
            }
        }

        return false;
    }
   
}
