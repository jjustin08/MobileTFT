using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Team : MonoBehaviour
{
    //[SerializeField] private List<GameObject> pawns = new List<GameObject>();
    [SerializeField] private List<GameObject> savedPawns = new List<GameObject>();
    [SerializeField] private List<SlotPosition> savedSlotPositions = new List<SlotPosition>();
    // list of pawns
    // also want know there location
    // will load team into battle field
    // probably set it to enemy
    // for multiplayer positions cant be same need to reverse

    private void Update()
    {
        
    }

    public void SaveTeam(bool friendly)
    {
        foreach (Slot slot in GridUtil.Instance.GetOneSideOfSlots(friendly))
        {
            if (slot.GetPawn() != null)
            {
                GameObject newPawn = Instantiate(slot.GetPawn().gameObject, transform);
                savedPawns.Add(newPawn);
                savedSlotPositions.Add(slot.GetSlotPos());
                newPawn.SetActive(false);
            }
        }
    }

    public void LoadTeam(bool friendly) 
    {
        for (int i = 0; i< savedPawns.Count; i++)
        {
            //GameObject newPawn = Instantiate(p, transform);
            //savedPawns.Add(newPawn);
            savedPawns[i].SetActive(true);
            Pawn pawn = savedPawns[i].GetComponent<Pawn>();
            if(friendly)
            {
                pawn.GetMovement().MoveToSlot(savedSlotPositions[i].GetSlot());
            }
            else
            {
                pawn.GetMovement().MoveToSlot(GridUtil.Instance.GetOppositeSlot(savedSlotPositions[i]).GetSlot());
            }
            
        }

    }
}
