using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BotTeam", menuName = "BotTeam/BotTeam")]
public class BotTeamSO : ScriptableObject
{
    public List<PawnSO> savedPawnSOs = new List<PawnSO>();
    public List<Vector2Int> savedSlotPositions = new List<Vector2Int>();

    public void LoadTeam()
    {
        for (int i = 0; i < savedPawnSOs.Count; i++)
        {
            Pawn newPawn = Instantiate(savedPawnSOs[i].placedPawn);
            newPawn.SetPawnSO(savedPawnSOs[i]);
            newPawn.SetEnemy(true);
            newPawn.transform.Rotate(0f, 180f, 0f);
            newPawn.GetStats().CalculateStats(true);
            GridUtil.Instance.GetSlotPositionFromVector2(savedSlotPositions[i]).GetSlot().PlacePawn(newPawn);
        }
    }
}
