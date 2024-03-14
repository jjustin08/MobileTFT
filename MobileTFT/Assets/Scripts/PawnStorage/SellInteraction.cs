using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellInteraction : MonoBehaviour
{
    [SerializeField] private GameObject SellUi;

    private void Update()
    {
        // probably should not put this in update
        GameObject interceptObj = Player.Instance.GetPlayerInput().TestCardTileIntercept();
        if (interceptObj == this.gameObject && Player.Instance.GetHoldingPawn() != null)
        {
            // this is broke
            if(SellUi != null) 
            SellUi.SetActive(true);
        }
        else
        {
            SellUi.SetActive(false);
        }
    }

    public void SellPawn()
    {
        Pawn p = Player.Instance.GetHoldingPawn();
        p.GetMovement().GetSlot().RemovePawn();

        //TODO sell actions
        CashManager.Instance.GainCash(p.cost);
        Destroy(p.gameObject);
    }
}
