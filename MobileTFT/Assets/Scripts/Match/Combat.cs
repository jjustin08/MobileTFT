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
        if(Input.GetKeyDown(KeyCode.S)) 
        {
            EndCombat();
        }
    }

    private void StartCombat()
    {
        foreach (Pawn p in MovementUtil.Instance.GetAllPawns()) 
        {
            p.GetAI().ToggleCombatMode(true);
        }
        // disable input from player
        // activate all pawns
    }

    private void EndCombat()
    {
        foreach (Pawn p in MovementUtil.Instance.GetAllPawns())
        {
            p.GetAI().ToggleCombatMode(false);
        }
    }
}
