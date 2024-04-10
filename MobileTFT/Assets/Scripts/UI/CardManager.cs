using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardSlotUI> shopPawnsSlots;

    //shared pool of pawns
    [SerializeField] private List<PawnSO> pawnPool;
    private List<PawnSO> OneCostPool = new List<PawnSO>();
    private List<PawnSO> TwoCostPool = new List<PawnSO>();
    private List<PawnSO> ThreeCostPool = new List<PawnSO>();
    private List<PawnSO> FourCostPool = new List<PawnSO>();
    private List<PawnSO> FiveCostPool = new List<PawnSO>();

    [SerializeField] private PawnStorage pawnStorage;


    private void Start()
    {
        foreach(PawnSO so in pawnPool) 
        {
            for(int i = 0; i < 12; i++)
            AddPawnToDeck(so);
        }
    }
    public void ReRollPawns()
    {
        int level = Player.Instance.GetPlayerStats().GetPlayerLevel();


        foreach (CardSlotUI slot in shopPawnsSlots)
        {
            PawnSO removedPawnSO = slot.RemovePawn();
            if (removedPawnSO != null)
            {
                AddPawnToDeck(removedPawnSO);
            }


            // TODO: refactor?
            int perc = Random.Range(0, 100);
            switch (level)
            {
                case 1:
                    // only 1 cost 
                    DrawCardFromPool(OneCostPool, slot);
                break; case 2:
                    if(perc > 80)
                    {
                        DrawCardFromPool(TwoCostPool, slot);
                    }
                    else if(perc >= 0)
                    {
                        DrawCardFromPool(OneCostPool, slot);
                    }

                break; case 3:
                    if (perc > 90)
                    {
                        DrawCardFromPool(ThreeCostPool, slot);
                    }
                    else if(perc > 60)
                    {
                        DrawCardFromPool(TwoCostPool, slot);
                    }
                    else if(perc >= 0)
                    {
                        DrawCardFromPool(OneCostPool, slot);
                    }

                break; case 4:
                    if (perc > 95)
                    {
                        DrawCardFromPool(FourCostPool, slot);
                    }
                    else if (perc > 60)
                    {
                        DrawCardFromPool(ThreeCostPool, slot);
                    }
                    else if(perc > 30)
                    {
                        DrawCardFromPool(TwoCostPool, slot);
                    }
                    else if(perc >= 0)
                    {
                        DrawCardFromPool(OneCostPool, slot);
                    }

                break; case 5:
                    if (perc > 95)
                    {
                        DrawCardFromPool(FiveCostPool, slot);
                    }
                    else if (perc > 85)
                    {
                        DrawCardFromPool(FourCostPool, slot);
                    }
                    else if (perc > 60)
                    {
                        DrawCardFromPool(ThreeCostPool, slot);
                    }
                    else if (perc > 30)
                    {
                        DrawCardFromPool(TwoCostPool, slot);
                    }
                    else if (perc >= 0)
                    {
                        DrawCardFromPool(OneCostPool, slot);
                    }

                    break; case 6:
                    if (perc > 80)
                    {
                        DrawCardFromPool(FiveCostPool, slot);
                    }
                    else if (perc > 50)
                    {
                        DrawCardFromPool(FourCostPool, slot);
                    }
                    else if (perc > 30)
                    {
                        DrawCardFromPool(ThreeCostPool, slot);
                    }
                    else if (perc > 15)
                    {
                        DrawCardFromPool(TwoCostPool, slot);
                    }
                    else if (perc >= 0)
                    {
                        DrawCardFromPool(OneCostPool, slot);
                    }

                    break; case 7:
                    if (perc > 70)
                    {
                        DrawCardFromPool(FiveCostPool, slot);
                    }
                    else if (perc > 35)
                    {
                        DrawCardFromPool(FourCostPool, slot);
                    }
                    else if (perc > 20)
                    {
                        DrawCardFromPool(ThreeCostPool, slot);
                    }
                    else if (perc > 10)
                    {
                        DrawCardFromPool(TwoCostPool, slot);
                    }
                    else if (perc >= 0)
                    {
                        DrawCardFromPool(OneCostPool, slot);
                    }
                    break;
            }



        }
        
    }

    private void DrawCardFromPool(List<PawnSO> pool, CardSlotUI slot)
    {
        if (pool.Count > 0)
        {
            PawnSO newPawnSO = pool[Random.Range(0, pool.Count - 1)];
            slot.PlaceShopPawn(newPawnSO);
            pool.Remove(newPawnSO);
        }
    }

    public bool BuyPawn(Card shopPawn)
    {
        if (CashManager.Instance.RemoveCash(shopPawn.GetPawnSO().cost))
        {
            pawnStorage.FillSlot(shopPawn.GetPawnSO(), 0, 0);
            return true;
        }
       return false;
        
    }


    public void AddPawnToDeck(PawnSO SO)
    {
        PawnSO realSO = SO;
        int amount = 1;
        if(SO.starCount == 3)
        {
            realSO = SO.prevStarPawnSO.prevStarPawnSO;
            amount = 9;
        }
        else if(SO.starCount == 2)
        {
            realSO = SO.prevStarPawnSO;
            amount = 3;
        }

        int cost = realSO.cost;
        for(int i = 0; i < amount; i++) 
        {
            switch (cost)
            {
                case 1:
                    OneCostPool.Add(realSO);

                    break;
                case 2:
                    TwoCostPool.Add(realSO);

                    break;
                case 3:
                    ThreeCostPool.Add(realSO);

                    break;
                case 4:
                    FourCostPool.Add(realSO);

                    break;
                case 5:
                    FiveCostPool.Add(realSO);

                    break;
            }
        }
    }
}
