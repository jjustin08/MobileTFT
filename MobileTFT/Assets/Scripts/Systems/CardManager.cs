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
        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[1]);

        switch (signifier) 
        {
            case CardManagerSignifyers.ReRoll:
                RecieveNewCards(int.Parse(csv[2]) != 0, int.Parse(csv[3]), int.Parse(csv[4]), int.Parse(csv[5]), int.Parse(csv[6]), int.Parse(csv[7]));
                break;
            case CardManagerSignifyers.BuyPawn:
                RecieveBuyPawn(int.Parse(csv[2]) != 0, int.Parse(csv[3]), csv[4]);
                break;
        }
    }

    public void RequestCardReRoll()
    {
        //send message to server to reroll cards
        string msg = ClientToServerSignifiers.CardManager + "," + CardManagerSignifyers.ReRoll;
        NetworkClientProcessing.SendMessageToServer(msg, TransportPipeline.ReliableAndInOrder);
    }

    private void RecieveNewCards(bool allowed, int card1, int card2, int card3, int card4, int card5)
    {
        if(!allowed) 
        {
            return;
        }
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
                int slotIndex = shopPawnsSlots.IndexOf(cardSlot);
                //send message to server
                string msg = ClientToServerSignifiers.CardManager + "," + CardManagerSignifyers.BuyPawn + ","+
                    slotIndex;
                NetworkClientProcessing.SendMessageToServer(msg, TransportPipeline.ReliableAndInOrder);

                
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
