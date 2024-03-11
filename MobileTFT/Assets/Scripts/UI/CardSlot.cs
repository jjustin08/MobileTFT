using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSlot : MonoBehaviour
{
    [SerializeField] private CardManager pawnShop;
    private Card shopPawn;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            if(shopPawn != null) 
            {
                pawnShop.BuyPawn(shopPawn);
                Destroy(shopPawn.gameObject);
                shopPawn = null;
            }
        });
    }

    public void PlaceShopPawn(Card newShopPawn)
    {
        shopPawn = Instantiate(newShopPawn, transform);
    }
}
