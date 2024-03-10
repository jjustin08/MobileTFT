using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private PawnShop pawnShop;
    private List<Pawn> pawns = new List<Pawn>();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCombat();
        }
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            EndCombat();
        }
    }

    private void StartCombat()
    {
        foreach (Pawn p in MovementUtil.Instance.GetAllPawns()) 
        {
            pawns.Add(p);
            p.GetAI().ToggleCombatMode(true);
        }
        //TODO disable input from player
  
    }

    private void EndCombat()
    {
        foreach (Pawn p in pawns)
        {
            if(p.gameObject.activeSelf)
            {
                p.GetAI().ToggleCombatMode(false);
            }
            else
            {
                
                pawnShop.AddPawnToDeck();
                Destroy(p.gameObject);
            }
            
        }
        pawns.Clear();
    }
}
