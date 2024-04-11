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

    private void Update()
    {

        if (Player.Instance.GetHoldingPawn() != null)
        {
            foreach (Slot s in slots)
            {
                s.GetSlotInteraction().gameObject.SetActive(true);

            }
        }
        else
        {
            foreach (Slot s in slots)
            {
                s.GetSlotInteraction().gameObject.SetActive(false);

            }
        }
    }


    public bool FillSlot(PawnSO SO, int killCount, int deathCount)
    {
        foreach (Slot slot in slots) 
        { 
            if(!slot.HasPawn())
            {
                Pawn newPawn = Instantiate(SO.placedPawn);
                newPawn.SetPawnSO(SO);
                slot.PlacePawn(newPawn);
                newPawn.GetStats().SetKillCount(killCount);
                newPawn.GetStats().SetDeathCount(deathCount);
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

        if(counter == 3 && SO.nextStarPawnSO != null)
        {
            int killCount = 0;
            int deathCount = 0;
            foreach(Pawn pawn in countedPawns)
            {
                killCount += pawn.GetStats().GetKillCount();
                deathCount += pawn.GetStats().GetDeathCount();
                pawn.SelfDestruct();

            }
            FillSlot(SO.nextStarPawnSO, killCount, deathCount);
        }

    }
   
}
