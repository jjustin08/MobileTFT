using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardSlot> shopPawnsSlots;

    [SerializeField] private List<Card> shopPawnsDeck;

    [SerializeField] private PawnStorage pawnStorage;

    [SerializeField] private Card tempDeadPawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReRollPawns();
        }
    }

    public void ReRollPawns()
    {
        foreach(CardSlot slot in shopPawnsSlots)
        {
            slot.PlaceShopPawn(shopPawnsDeck[Random.Range(0, shopPawnsDeck.Count-1)]);
        }
    }

    public void BuyPawn(Card shopPawn)
    {
        pawnStorage.FillSlot(shopPawn.GetPawn());
    }


    public void AddPawnToDeck()
    {
        shopPawnsDeck.Add(tempDeadPawn);
        //temp value
    }
}
