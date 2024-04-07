using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    [SerializeField] private PawnManager pawnManager;
    private List<Pawn> pawns = new List<Pawn>();


    public bool IsCombatOver()
    {
        
        if (pawns.Count == 0) return false;

        int aliveFriendly = 0;
        int aliveEnemy = 0;

        foreach (Pawn p in pawns)
        {
            if (p.IsEnemy() && p.gameObject.activeSelf)
            {
                aliveEnemy++;
            }
            if (!p.IsEnemy() && p.gameObject.activeSelf)
            {
                aliveFriendly++;
            }
        }

        if(aliveFriendly == 0 || aliveEnemy == 0) 
        {
            return true;
        }

        return false;
    }

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
            Player.Instance.GetPlayerStats().TakeDamage(aliveEnemy);
            return 2;
        }
        else if(aliveEnemy == 0)
        {
            return 1;
        }
        else
        {
            return 3;
        }
    }

    public void StartCombat()
    {
        pawnManager.ToggleCombat(true);
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

        pawnManager.ToggleCombat(false);
        pawnManager.UpdatePawns();
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
                //hard coding this
                if(p.GetPawnSO().types.Contains(new UndeadType()))
                {
                    print("undead died");
                    p.ToggleCombat(false);
                    p.GetStats().SetDeathCount(p.GetStats().GetDeathCount() + 1);
                }
                else
                {
                    cardManager.AddPawnToDeck(p.GetPawnSO());
                    CashManager.Instance.GainCash(p.GetPawnSO().cost);
                    p.SelfDestruct();
                }
               
            }

        }
        pawns.Clear();
    }
}
