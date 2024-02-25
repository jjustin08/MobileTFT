using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private List<Pawn> pawnList;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCombat();
        }
    }

    private void StartCombat()
    {

    }
}
