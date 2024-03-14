using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    [SerializeField] private CardManager pawnShop;
    private Card card;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            if(card != null) 
            {
                if(pawnShop.BuyPawn(card))
                {
                    Destroy(card.gameObject);
                    card = null;
                }

            }
        });
    }

    public void PlaceShopPawn(PawnSO newPawnSO)
    {
        card = Instantiate(newPawnSO.cardPawn, transform);
        card.SetPawnSO(newPawnSO);
    }
}
