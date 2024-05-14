using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellInteraction : MonoBehaviour
{
    [SerializeField] private GameObject SellUi;
    [SerializeField] private CardManager CardManager;
    private void Update()
    {
        // probably should not put this in update
        //GameObject interceptObj = Player.Instance.GetPlayerInput().TestCardTileIntercept();
        if (Player.Instance.GetHoldingPawn() != null)
        {
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


        CardManager.AddPawnToDeck(p.GetPawnSO(), p.GetStats().GetStarCount());

        int pawnCost = 0;
        pawnCost = p.GetPawnSO().cost;
        if (p.GetStats().GetStarCount() == 2) 
        {
            pawnCost = p.GetPawnSO().cost * 3;
        }
        else if(p.GetStats().GetStarCount() == 3)
        {
            pawnCost = p.GetPawnSO().cost * 9;
        }
        Player.Instance.GetPlayerStats().GainCash(pawnCost);
        Destroy(p.gameObject);
    }
}
