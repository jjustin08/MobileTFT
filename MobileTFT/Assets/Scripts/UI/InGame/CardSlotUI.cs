using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlotUI : MonoBehaviour
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
        card = Instantiate(newPawnSO.cardVisual, transform);
        card.SetPawnSO(newPawnSO);
    }

    public PawnSO RemovePawn()
    {
        if(card != null ) 
        {
            PawnSO tempSO = card.GetPawnSO();

            Destroy(card.gameObject);
            card = null;
            return tempSO;
        }


        return null;
    }
}
