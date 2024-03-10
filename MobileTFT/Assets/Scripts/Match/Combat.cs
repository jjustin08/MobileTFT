using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {

            StartCombat();
        }
    }

    private void StartCombat()
    {
        foreach (Pawn p in MovementUtil.Instance.GetAllPawns()) 
        {
            p.GetAI().ActivateCombatMode();
        }
        // disable input from player
        // activate all pawns
    }

    private void EndCombat()
    {
        //reset all pawns except dead ones?
    }
}
