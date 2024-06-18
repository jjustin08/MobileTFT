using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

static public class CardManager
{
    static public void RecieveMessage(string msg, int clientID)
    {
        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[1]);

        switch (signifier)
        {
            case CardManagerSignifyers.ReRoll:
                RequestReRoll(clientID);
                break;
            case CardManagerSignifyers.BuyPawn:
                //this might want to be in player
                // need to update cash
                RequestBuyPawn(clientID, int.Parse(csv[2]));
                break;
        }

    }

    static private void RequestReRoll(int clientID)
    {
        Player tempPlayer = Lobby.GetPlayerById(clientID);

        List<PawnData> tempCardList = new List<PawnData>();
        tempCardList.Add(PawnDataBase.pawns[1]);
        tempCardList.Add(PawnDataBase.pawns[1]);
        tempCardList.Add(PawnDataBase.pawns[1]);
        tempCardList.Add(PawnDataBase.pawns[1]);
        tempCardList.Add(PawnDataBase.pawns[1]);
        tempPlayer.GetPlayerStats().SetCards(tempCardList);
       

        string msg = ServerToClientSignifiers.CardManager + "," + CardManagerSignifyers.ReRoll + "," +
            1 + "," + 1 + "," + 1 + "," + 1 + "," + 1 + "," + 1;
        NetworkServerProcessing.SendMessageToClient(msg, clientID, TransportPipeline.ReliableAndInOrder);
    }


    static private void RequestBuyPawn(int clientID, int slotIndex)
    {
        //check if pawn storage is full
        // check if enough money
        // check if there is actually a card to buy
        string msg = ServerToClientSignifiers.CardManager + "," + CardManagerSignifyers.BuyPawn + "," +
            1 + "," + slotIndex + "," + "allgood";
        NetworkServerProcessing.SendMessageToClient(msg, clientID, TransportPipeline.ReliableAndInOrder);

        Player tempPlayer = Lobby.GetPlayerById(clientID);

        if(tempPlayer != null) 
        {
            PawnData tempData = tempPlayer.GetPlayerStats().GetCards()[slotIndex];

            tempPlayer.GetPlayerStats().AddPawn(tempData, new Vector2Int(-1,-1),clientID);
        }
    }

    //    int level = Player.Instance.GetPlayerStats().GetPlayerLevel();


    //    foreach (CardSlotUI slot in shopPawnsSlots)
    //    {
    //        PawnSO removedPawnSO = slot.RemovePawn();
    //        if (removedPawnSO != null)
    //        {
    //            AddPawnToDeck(removedPawnSO, 1);
    //        }


    //        // TODO: refactor?
    //        int perc = Random.Range(0, 100);
    //        switch (level)
    //        {
    //            case 1:
    //                // only 1 cost 
    //                DrawCardFromPool(OneCostPool, slot);
    //            break; case 2:
    //                if(perc > 80)
    //                {
    //                    DrawCardFromPool(TwoCostPool, slot);
    //                }
    //                else if(perc >= 0)
    //                {
    //                    DrawCardFromPool(OneCostPool, slot);
    //                }

    //            break; case 3:
    //                if (perc > 90)
    //                {
    //                    DrawCardFromPool(ThreeCostPool, slot);
    //                }
    //                else if(perc > 60)
    //                {
    //                    DrawCardFromPool(TwoCostPool, slot);
    //                }
    //                else if(perc >= 0)
    //                {
    //                    DrawCardFromPool(OneCostPool, slot);
    //                }

    //            break; case 4:
    //                if (perc > 95)
    //                {
    //                    DrawCardFromPool(FourCostPool, slot);
    //                }
    //                else if (perc > 60)
    //                {
    //                    DrawCardFromPool(ThreeCostPool, slot);
    //                }
    //                else if(perc > 30)
    //                {
    //                    DrawCardFromPool(TwoCostPool, slot);
    //                }
    //                else if(perc >= 0)
    //                {
    //                    DrawCardFromPool(OneCostPool, slot);
    //                }

    //            break; case 5:
    //                if (perc > 95)
    //                {
    //                    DrawCardFromPool(FiveCostPool, slot);
    //                }
    //                else if (perc > 85)
    //                {
    //                    DrawCardFromPool(FourCostPool, slot);
    //                }
    //                else if (perc > 60)
    //                {
    //                    DrawCardFromPool(ThreeCostPool, slot);
    //                }
    //                else if (perc > 30)
    //                {
    //                    DrawCardFromPool(TwoCostPool, slot);
    //                }
    //                else if (perc >= 0)
    //                {
    //                    DrawCardFromPool(OneCostPool, slot);
    //                }

    //                break; case 6:
    //                if (perc > 80)
    //                {
    //                    DrawCardFromPool(FiveCostPool, slot);
    //                }
    //                else if (perc > 50)
    //                {
    //                    DrawCardFromPool(FourCostPool, slot);
    //                }
    //                else if (perc > 30)
    //                {
    //                    DrawCardFromPool(ThreeCostPool, slot);
    //                }
    //                else if (perc > 15)
    //                {
    //                    DrawCardFromPool(TwoCostPool, slot);
    //                }
    //                else if (perc >= 0)
    //                {
    //                    DrawCardFromPool(OneCostPool, slot);
    //                }

    //                break; case 7:
    //                if (perc > 70)
    //                {
    //                    DrawCardFromPool(FiveCostPool, slot);
    //                }
    //                else if (perc > 35)
    //                {
    //                    DrawCardFromPool(FourCostPool, slot);
    //                }
    //                else if (perc > 20)
    //                {
    //                    DrawCardFromPool(ThreeCostPool, slot);
    //                }
    //                else if (perc > 10)
    //                {
    //                    DrawCardFromPool(TwoCostPool, slot);
    //                }
    //                else if (perc >= 0)
    //                {
    //                    DrawCardFromPool(OneCostPool, slot);
    //                }
    //                break;
    //        }



    //    }

    //}
}

static public class CardManagerSignifyers
{
    public const int ReRoll = 1;
    public const int BuyPawn = 2;
}
