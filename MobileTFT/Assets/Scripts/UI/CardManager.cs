using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardSlot> shopPawnsSlots;

    [SerializeField] private List<Card> sharedPool;

    [SerializeField] private PawnStorage pawnStorage;


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
            if(sharedPool.Count > 0)
            {
                Card newCard = sharedPool[Random.Range(0, sharedPool.Count - 1)];
                slot.PlaceShopPawn(newCard);
                sharedPool.Remove(newCard);
            }
        }
    }

    public bool BuyPawn(Card shopPawn)
    {
        Pawn pawn = shopPawn.GetPawn();
        if (CashManager.Instance.RemoveCash(pawn.cost))
        {
            Destroy(shopPawn.gameObject);
            pawnStorage.FillSlot(pawn);
            return true;
        }
       return false;
        
    }


    public void AddPawnToDeck()
    {
        // need to add pawn to card functions
        // for selling as well
    }
}
