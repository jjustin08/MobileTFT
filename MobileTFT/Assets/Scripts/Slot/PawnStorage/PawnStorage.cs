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

    public bool IsStorageFull()
    {
        bool isFull = true;
        isFull = false;
        foreach (Slot s in slots)
        {
            if(!s.HasPawn()) 
            {
                isFull = false;
                continue;
            }
        }
        return isFull;
    }

    public Pawn FillSlot(PawnData data, int killCount, int deathCount, int starCount)
    {
        foreach (Slot slot in slots) 
        {
            if (!slot.HasPawn())
            {
                GameObject pawnObject = Instantiate(data.placedPawn);
                Pawn newPawn = pawnObject.GetComponent<Pawn>();
                newPawn.SetPawnData(data);
                slot.PlacePawn(newPawn);
                newPawn.GetStats().SetKillCount(killCount);
                newPawn.GetStats().SetDeathCount(deathCount);
                newPawn.GetStats().SetStarCount(starCount);
                //CheckForTriple(SO, newPawn.GetStats().GetStarCount());
                return newPawn;
            }
        }

        return null;
    }

    //private void CheckForTriple(PawnSO SO, int starCount)
    //{
    //    int counter = 0;
    //    List<Pawn> countedPawns = new List<Pawn>();

    //    foreach (Pawn pawn in GridUtil.Instance.GetAllPawns(true))
    //    {
    //        if (pawn.GetPawnSO() == SO)
    //        {
    //            if (pawn.GetStats().GetStarCount() == starCount)
    //            {
    //                counter++;
    //                countedPawns.Add(pawn);
    //            }
    //        }
    //    }

    //    foreach (Slot slot in slots) 
    //    { 
    //        if(slot.HasPawn()) 
    //        { 
    //            if(slot.GetPawn().GetPawnSO() == SO)
    //            {
    //                if(slot.GetPawn().GetStats().GetStarCount() == starCount)
    //                {
    //                    counter++;
    //                    countedPawns.Add(slot.GetPawn());
    //                } 
    //            }
    //        }
    //    }

        

    //    if(counter == 3)
    //    {
    //        int killCount = 0;
    //        int deathCount = 0;
    //        foreach(Pawn pawn in countedPawns)
    //        {
    //            killCount += pawn.GetStats().GetKillCount();
    //            deathCount += pawn.GetStats().GetDeathCount();
    //        }

    //        countedPawns[0].GetStats().SetStarCount(starCount + 1);
    //        countedPawns[0].GetStats().SetDeathCount(deathCount);
    //        countedPawns[0].GetStats().SetKillCount(killCount);
            

    //        countedPawns[1].SelfDestruct();
    //        countedPawns[2].SelfDestruct();

    //        CheckForTriple(SO, starCount + 1);
    //    }

    //}
   
}
