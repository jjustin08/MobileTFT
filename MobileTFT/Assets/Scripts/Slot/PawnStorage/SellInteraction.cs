using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void RequestSellPawn(PawnData pawnData, int triple)
    {
        string msg = ClientToServerSignifiers.CardManager +"," + CardManagerSignifyers.SellPawn + "," + pawnData.index + "," + triple;

        NetworkClientProcessing.SendMessageToServer(msg, TransportPipeline.ReliableAndInOrder);
    }
    public void RecieveSellPawn()
    {
        Pawn p = Player.Instance.GetHoldingPawn();
        p.GetMovement().GetSlot().RemovePawn();
        Destroy(p.gameObject);
    }
}
