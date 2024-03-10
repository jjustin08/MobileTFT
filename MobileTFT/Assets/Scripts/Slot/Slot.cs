using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Pawn placedPawn;
    private bool hasPawn;
    public void PlacePawn(Pawn p)
    {
        p.transform.SetParent(transform, false);
        placedPawn = p;
        p.GetComponent<PawnMovement>().SetSlot(this);
        hasPawn = true;
    }

    public void RemovePawn()
    {
        placedPawn = null;
        hasPawn = false;
    }
    public Pawn GetPawn()
    {
        return placedPawn;
    }

    public TilePosition GetTilePos()
    {
        return GetComponent<TilePosition>();
    }

    public bool HasPawn()
    {
        return hasPawn;
    }
}
