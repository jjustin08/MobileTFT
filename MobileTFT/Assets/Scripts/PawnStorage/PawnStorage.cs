using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PawnStorage : MonoBehaviour
{
    private List<Slot> slots = new List<Slot>();

    void Start()
    {
        slots.AddRange(GetComponentsInChildren<Slot>());
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
                CheckForTriple(SO);
                return true;
            }
        }

        return false;
    }

    private void CheckForTriple(PawnSO SO)
    {
        int counter = 0;
        List<Pawn> countedPawns = new List<Pawn>();

        foreach (Slot slot in slots) 
        { 
            if(slot.HasPawn()) 
            { 
                if(slot.GetPawn().GetPawnSO() == SO)
                {
                    counter++;
                    countedPawns.Add(slot.GetPawn());
                }
            }
        }

        foreach(Pawn pawn in GridUtil.Instance.GetAllPawns(true))
        {
            if(pawn.GetPawnSO() == SO)
            {
                counter++;
                countedPawns.Add(pawn);
            }
        }

        if(counter == 3 && SO.TwoStarPawnSO != null)
        {
            foreach(Pawn pawn in countedPawns)
            {
                pawn.SelfDestruct();
            }
            FillSlot(SO.TwoStarPawnSO);
        }

    }
   
}
