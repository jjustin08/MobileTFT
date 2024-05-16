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
                pawnShop.RequestBuyPawn(this);
            }
        });
    }

    public void PlaceCard(PawnData newPawnData)
    {
        GameObject cardObject = Instantiate(newPawnData.cardVisual, transform);
        card = cardObject.GetComponent<Card>();
        card.SetPawnData(newPawnData);
    }

    public void RemoveCard()
    {
        if(card != null ) 
        {
            Destroy(card.gameObject);
            card = null;
        }
    }

    public Card GetCard()
    {
        return card;
    }
}
