using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private PawnData pawnData;
    private CardUI cardVisual;


    private void Awake()
    {
        cardVisual = GetComponent<CardUI>();
    }
    public void SetPawnData(PawnData data)
    {
        pawnData = data;
        cardVisual.UpdateVisual(data);
    }

    public PawnData GetPawnData() { return pawnData; }
}
