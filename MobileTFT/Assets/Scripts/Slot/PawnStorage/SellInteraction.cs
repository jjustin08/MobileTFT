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

    public void RequestSellPawn(Pawn pawn, int triple)
    {
        int index = Player.Instance.GetPlayerStats().GetPawnList().IndexOf(pawn);

        string msg = ClientToServerSignifiers.Player +"," + PlayerSignifiers.SellPawn + "," + index + "," + triple;

        NetworkClientProcessing.SendMessageToServer(msg, TransportPipeline.ReliableAndInOrder);
    }
}
