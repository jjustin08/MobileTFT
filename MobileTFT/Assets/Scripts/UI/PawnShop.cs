using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnShop : MonoBehaviour
{
    [SerializeField] private List<ShopPawnSlot> shopPawnsSlots;

    [SerializeField] private List<ShopPawn> shopPawnsDeck;

    [SerializeField] private PawnStorage pawnStorage;

    [SerializeField] private ShopPawn tempDeadPawn;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReRollPawns();
        }
    }

    public void ReRollPawns()
    {
        foreach(ShopPawnSlot slot in shopPawnsSlots)
        {
            slot.PlaceShopPawn(shopPawnsDeck[Random.Range(0, shopPawnsDeck.Count-1)]);
        }
    }

    public void BuyPawn(ShopPawn shopPawn)
    {
        pawnStorage.FillSlot(shopPawn.GetPawn());
    }


    public void AddPawnToDeck()
    {
        shopPawnsDeck.Add(tempDeadPawn);
        //temp value
    }
}
