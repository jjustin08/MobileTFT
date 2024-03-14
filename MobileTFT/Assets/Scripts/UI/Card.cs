using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private PawnSO pawnSO;

    public void SetPawnSO(PawnSO SO)
    {
        pawnSO = SO;
    }

    public PawnSO GetPawnSO() { return pawnSO; }
}
