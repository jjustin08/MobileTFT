using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private CardManager cardManager;
    private List<Pawn> pawns = new List<Pawn>();
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
    }

    private void StartCombat()
    {
        
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
