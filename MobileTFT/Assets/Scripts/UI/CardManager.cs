using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardSlot> shopPawnsSlots;

    [SerializeField] private List<PawnSO> sharedPool;

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
                PawnSO removedPawnSO = slot.RemovePawn();
                if(removedPawnSO != null)
                {
                    AddPawnToDeck(removedPawnSO);
                }
               
                PawnSO newPawnSO = sharedPool[Random.Range(0, sharedPool.Count - 1)];

                slot.PlaceShopPawn(newPawnSO);
                sharedPool.Remove(newPawnSO);
            }
        }
    }

    public bool BuyPawn(Card shopPawn)
    {
        if (CashManager.Instance.RemoveCash(shopPawn.GetPawnSO().cost))
        {
            pawnStorage.FillSlot(shopPawn.GetPawnSO());
            return true;
        }
       return false;
        
    }


    public void AddPawnToDeck(PawnSO SO)
    {
        sharedPool.Add(SO);
    }
}
