using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PawnStorage : MonoBehaviour
{
    private List<Slot> slots = new List<Slot>();

    public Pawn tempPawn;
    void Start()
    {
        slots.AddRange(GetComponentsInChildren<Slot>());
    }
    private void Update()
    {
        // debug input
        if(Input.GetKeyDown(KeyCode.E))
        {
            FillSlot(tempPawn);
        }
    }

    public bool FillSlot(Pawn pawn)
    {
        foreach (Slot slot in slots) 
        { 
            if(!slot.HasPawn())
            {
                Pawn newPawn = Instantiate(pawn);
                slot.PlacePawn(newPawn);
                return true;
            }
        }

        return false;
    }
   
}
