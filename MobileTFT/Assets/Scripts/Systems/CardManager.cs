using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardSlotUI> shopPawnsSlots;

    [SerializeField] private PawnStorage pawnStorage;


    private void Start()
    {
        NetworkClientProcessing.SetCardManager(this);
    }

    public void RecieveServerMessage(string msg)
    {

        //int.Parse(csv[1]) != 0, int.Parse(csv[2]), csv[3]
    }

    public void RequestCardReRoll()
    {
        //send message to server to reroll cards
        string msg = "";
        NetworkClientProcessing.SendMessageToServer(msg, TransportPipeline.ReliableAndInOrder);
    }

    private void RecieveNewCards(int card1, int card2, int card3, int card4, int card5)
    {
        shopPawnsSlots[0].PlaceCard(PawnDataBase.pawns[card1]);
        shopPawnsSlots[1].PlaceCard(PawnDataBase.pawns[card2]);
        shopPawnsSlots[2].PlaceCard(PawnDataBase.pawns[card3]);
        shopPawnsSlots[3].PlaceCard(PawnDataBase.pawns[card4]);
        shopPawnsSlots[4].PlaceCard(PawnDataBase.pawns[card5]);
    }

    public void RequestBuyPawn(CardSlotUI cardSlot)
    {
        if(!pawnStorage.IsStorageFull())
        {
            if (Player.Instance.GetPlayerStats().GetCash() >= cardSlot.GetCard().GetPawnData().cost)
            {
                //send message to server
                int slotIndex = shopPawnsSlots.IndexOf(cardSlot);
            }
            else
            {
                HelperUI.Instance.ActivateHelperText("Not Enough Gold");
            }
        }
        else
        {
            HelperUI.Instance.ActivateHelperText("Pawn Storage Full");
        } 
    }

    private void RecieveBuyPawn(bool allowed,int slotIndex, string message)
    {
        if(allowed) 
        {
            PawnData pawnData = shopPawnsSlots[(int)slotIndex].GetCard().GetPawnData();

            Player.Instance.GetPlayerStats().RemoveCash(pawnData.cost);
            pawnStorage.FillSlot(pawnData, 0, 0, 1);

            shopPawnsSlots[(int)slotIndex].RemoveCard();
        }
        else
        {
            HelperUI.Instance.ActivateHelperText(message);
        }
    }
}

static public class CardManagerSignifyers
{
    public const int ReRoll = 1;
    public const int BuyPawn = 2;
}
