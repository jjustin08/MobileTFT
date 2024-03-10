using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPawnSlot : MonoBehaviour
{
    [SerializeField] private PawnShop pawnShop;
    private ShopPawn shopPawn;
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

    public void PlaceShopPawn(ShopPawn newShopPawn)
    {
        shopPawn = Instantiate(newShopPawn, transform);
    }
}
