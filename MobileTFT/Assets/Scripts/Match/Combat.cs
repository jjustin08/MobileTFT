using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    private List<Pawn> pawns = new List<Pawn>();

    public int CheckCombatState()
    {
        int aliveFriendly = 0;
        int aliveEnemy = 0;

        if (pawns.Count <= 0)
        {
            print("no pawns??");
            return -1;
        }
            

        foreach(Pawn p in pawns) 
        { 
            if(p.IsEnemy() && p.gameObject.activeSelf)
            {
                aliveEnemy++;
            }
            if(!p.IsEnemy() && p.gameObject.activeSelf)
            {
                aliveFriendly++;
            }
        }

        if (aliveFriendly == 0)
        {
            print("Lose");
            return 2;
        }
        else if(aliveEnemy == 0)
        {
            print("Win");
            return 1;
        }
        else
        {
            print("Tie");
            return 3;
        }
    }

    public void StartCombat()
    {
        foreach (Pawn p in GridUtil.Instance.GetAllPawns()) 
        {
            pawns.Add(p);
            p.ToggleCombat(true);
        }
    }

    public void EndCombat()
    {
        foreach (Pawn p in pawns)
        {
            //clear enemies
            if(p.IsEnemy()) 
            {
                p.SelfDestruct();
                continue;
            }

            //reset player's pawns
            if(p.gameObject.activeSelf)
            {
                p.ToggleCombat(false);
            }
            else
            {
                p.gameObject.SetActive(true);
                p.ToggleCombat(false);
            }
            
        }
        pawns.Clear();
    }

    public void EndCombatDeath()
    {
        foreach (Pawn p in pawns)
        {
            //clear enemies
            if (p.IsEnemy())
            {
                p.SelfDestruct();
                continue;
            }

            //reset player's pawns
            if (p.gameObject.activeSelf)
            {
                p.ToggleCombat(false);
            }
            else
            {
                cardManager.AddPawnToDeck(p.GetPawnSO());
                CashManager.Instance.GainCash(p.GetPawnSO().cost);
                p.SelfDestruct();
            }

        }
        pawns.Clear();
    }
}
