using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnData
{
    public GameObject placedPawn;
    public GameObject cardVisual;

    public PawnData(GameObject placedPawn, GameObject cardVisual)
    {
        this.placedPawn = placedPawn;
        this.cardVisual = cardVisual;
    }
}

public static class PawnDataBase
{
    public static Dictionary<PawnEnum, PawnData> pawns { get; } = new Dictionary<PawnEnum, PawnData>
    {
        {
            PawnEnum.Pawn1,
            new PawnData(
            placedPawn: Resources.Load<GameObject>("PlacedPawns/1"),
            cardVisual: Resources.Load<GameObject>("PlacedPawns/1"))
        },
        {
            PawnEnum.Pawn2,
            new PawnData(
            placedPawn: Resources.Load<GameObject>("PlacedPawns/2"),
            cardVisual: Resources.Load<GameObject>("PlacedPawns/2"))
        }
    };
}


public enum PawnEnum
{
    Pawn1,
    Pawn2,
}