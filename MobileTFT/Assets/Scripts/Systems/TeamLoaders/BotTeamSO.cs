using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BotTeam", menuName = "BotTeam/BotTeam")]
public class BotTeamSO : ScriptableObject
{
    //public List<PawnSO> pawnSOs = new List<PawnSO>();
    public List<int> triple = new List<int>();
    public List<int> killCount = new List<int>();
    public List<Vector2Int> slotPositions = new List<Vector2Int>();


    

    //public void LoadTeam()
    //{
    //    for (int i = 0; i < pawnSOs.Count; i++)
    //    {
    //        Pawn newPawn = Instantiate(pawnSOs[i].placedPawn);
    //        newPawn.SetPawnSO(pawnSOs[i]);
    //        newPawn.SetEnemy(true);
    //        newPawn.transform.Rotate(0f, 180f, 0f);
    //        newPawn.GetStats().CalculateStats(true);
    //        newPawn.GetStats().SetStarCount(triple[i]);
    //        newPawn.GetStats().SetKillCount(killCount[i]);
    //        GridUtil.Instance.GetSlotPositionFromVector2(slotPositions[i]).GetSlot().PlacePawn(newPawn);
    //    }
    //}
}
