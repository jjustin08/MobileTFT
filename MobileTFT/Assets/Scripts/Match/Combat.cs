using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    private List<Pawn> pawns = new List<Pawn>();

    private bool inCombat;
    void Update()
    {
        //debug input
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCombat();
        }
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            EndCombat();
        }

        // instead of update could do whenever a pawn dies. event maybe?
        if(inCombat)
        {
            CheckCombatState();
        }
        
    }

    private void CheckCombatState()
    {
        int aliveFriendly = 0;
        int aliveEnemy = 0;

        if (pawns.Count <= 0)
            return;

        foreach(Pawn p in pawns) 
        { 
            if(p.IsEnemy() && p.gameObject.activeSelf)
            {
                aliveFriendly++;
            }
            if(!p.IsEnemy() && p.gameObject.activeSelf)
            {
                aliveEnemy++;
            }
        }

        if (aliveFriendly == 0)
        {
            // make cash variable amount
            CashManager.Instance.GainCash(5);
            EndCombat();
        }
        else if(aliveEnemy == 0)
        {
            CashManager.Instance.GainCash(2);
            EndCombat();
        }
    }

    private void StartCombat()
    {
        inCombat = true;
        foreach (Pawn p in GridUtil.Instance.GetAllPawns()) 
        {
            pawns.Add(p);
            p.ToggleCombat(true);
        }

        foreach(Slot s in GridUtil.Instance.GetAllSlots())
        {
            s.GetSlotInteraction().ToggleInteraction(false);
        }
        
  
    }

    private void EndCombat()
    {
        inCombat = false;
        foreach (Pawn p in pawns)
        {
            if(p.gameObject.activeSelf)
            {
                p.ToggleCombat(false);
            }
            else
            {
                // what happens to destroyed pawns
                //reset like normal game
                p.gameObject.SetActive(true);
                p.ToggleCombat(false);

                // remove from place and put back into deck or dead deck
                //cardManager.AddPawnToDeck();
                //Destroy(p.gameObject);
            }
            
        }
        pawns.Clear();

        foreach (Slot s in GridUtil.Instance.GetAllSlots())
        {
            s.GetSlotInteraction().ToggleInteraction(true);
        }
    }
}
