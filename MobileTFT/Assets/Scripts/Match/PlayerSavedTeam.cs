using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSavedTeam : MonoBehaviour
{
    [SerializeField] private List<GameObject> savedPawns = new List<GameObject>();
    [SerializeField] private List<Vector2Int> savedSlotPositions = new List<Vector2Int>();
    

    public void SaveTeam(bool friendly)
    {
        foreach (Slot slot in GridUtil.Instance.GetOneSideOfSlots(friendly))
        {
            if (slot.GetPawn() != null)
            {
                GameObject newPawn = Instantiate(slot.GetPawn().gameObject, transform);
                savedPawns.Add(newPawn);
                savedSlotPositions.Add(slot.GetSlotPos().GetHexCoordinate());
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
            
            if (friendly)
            {
                pawn.SetEnemy(friendly);
                pawn.GetMovement().MoveToSlot(GridUtil.Instance.GetSlotPositionFromVector2(savedSlotPositions[i]).GetSlot());
            }
            else
            {
                pawn.SetEnemy(!friendly);
                pawn.GetMovement().MoveToSlot(GridUtil.Instance.GetOppositeSlot(GridUtil.Instance.GetSlotPositionFromVector2(savedSlotPositions[i])).GetSlot());
            }
            
        }

    }
}
