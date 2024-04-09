using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    private Slot currentSlot;

    private Slot startingSlot;

    public void ToggleCombat(bool toggle)
    {
        if (toggle)
        {
            startingSlot = GetSlot();
        }
        else
        {
            MoveToSlot(startingSlot);
            startingSlot = null;
            transform.rotation = Quaternion.identity;
        }
    }
    public void MoveToSlot(Slot s)
    {
        s.PlacePawn(GetComponent<Pawn>());
    }
    public void SetSlot(Slot s)
    {
        currentSlot = s;
    }

    public Slot GetSlot()
    {
        return currentSlot;
    }
   

   
}
