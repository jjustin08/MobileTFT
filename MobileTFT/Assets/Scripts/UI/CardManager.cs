using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<CardSlot> shopPawnsSlots;

    //shared pool of pawns
    [SerializeField] private List<PawnSO> OneCostPool;
    [SerializeField] private List<PawnSO> TwoCostPool;
    [SerializeField] private List<PawnSO> ThreeCostPool;
    [SerializeField] private List<PawnSO> FourCostPool;
    [SerializeField] private List<PawnSO> FiveCostPool;

    [SerializeField] private PawnStorage pawnStorage;

    public void ReRollPawns()
    {
        int level = Player.Instance.GetPlayerStats().GetPlayerLevel();


        foreach (CardSlot slot in shopPawnsSlots)
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

    private void DrawCardFromPool(List<PawnSO> pool, CardSlot slot)
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
            pawnStorage.FillSlot(shopPawn.GetPawnSO(), 0);
            return true;
        }
       return false;
        
    }


    public void AddPawnToDeck(PawnSO SO)
    {
        int cost = SO.cost;

        switch (cost)
        {
            case 1:
                OneCostPool.Add(SO);

            break; case 2:
                TwoCostPool.Add(SO);

            break; case 3:
                ThreeCostPool.Add(SO);

            break; case 4:
                FourCostPool.Add(SO);

            break; case 5: 
                FiveCostPool.Add(SO);

            break;
        
        
        }

        
    }
}
