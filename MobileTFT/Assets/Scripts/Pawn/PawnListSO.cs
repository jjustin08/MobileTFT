using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PawnList", menuName = "Pawn/PawnList")]
public class PawnListSO : ScriptableObject
{
    public List<PawnSO> Pawns;
}
