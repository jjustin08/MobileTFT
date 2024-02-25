using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour
{
    private Slot currentSlot;

    public void SetSlot(Slot s)
    {
        currentSlot = s;
    }


    public void MoveToSlot(Slot s)
    {
        currentSlot.RemovePawn();
        s.PlacePawn(gameObject);
    }
}
