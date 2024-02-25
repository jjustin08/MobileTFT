using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private GameObject placedPawn;

    public void PlacePawn(GameObject p)
    {
        p.transform.SetParent(transform, false);
        placedPawn = p;
        p.GetComponent<PawnMovement>().SetSlot(this);
    }

    public void RemovePawn()
    {
        placedPawn = null;
    }

    public TilePosition GetTilePos()
    {
        return GetComponent<TilePosition>();
    }
}
