using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private PawnSO pawnSO;
    private CardUI cardVisual;


    private void Awake()
    {
        cardVisual = GetComponent<CardUI>();
    }
    public void SetPawnSO(PawnSO SO)
    {
        pawnSO = SO;
        cardVisual.UpdateVisual(SO);
    }

    public PawnSO GetPawnSO() { return pawnSO; }
}
