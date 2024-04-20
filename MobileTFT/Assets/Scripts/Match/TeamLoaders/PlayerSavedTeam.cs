using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSavedTeam : MonoBehaviour
{
    [SerializeField] private List<PawnSO> savedPawnSOs = new List<PawnSO>();
    [SerializeField] private List<Vector2Int> savedSlotPositions = new List<Vector2Int>();
    

    public void SaveTeam(bool friendly)
    {
        //TODO save other stats
        foreach (Slot slot in GridUtil.Instance.GetOneSideOfSlots(friendly))
        {
            if (slot.GetPawn() != null)
            {
                savedPawnSOs.Add(slot.GetPawn().GetPawnSO());
                savedSlotPositions.Add(slot.GetSlotPos().GetHexCoordinate());
            }
        }
    }

    public void LoadTeam(bool friendly) 
    {
        // TODO server get a team from server and place as enemy
        // create so of all pawn so and just give index and relevent stats
        for (int i = 0; i < savedPawnSOs.Count; i++)
        {
            Pawn newPawn = Instantiate(savedPawnSOs[i].placedPawn);
            newPawn.SetPawnSO(savedPawnSOs[i]);
            newPawn.SetEnemy(true);
            newPawn.transform.Rotate(0f, 180f, 0f);
            GridUtil.Instance.GetSlotPositionFromVector2(savedSlotPositions[i]).GetSlot().PlacePawn(newPawn);
        }
    }
}
