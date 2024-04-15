using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pawn")]
public class PawnSO : ScriptableObject
{
    public int starCount = 1;
    public PawnSO prevStarPawnSO;
    public PawnSO nextStarPawnSO;

    public Pawn placedPawn;

    public Card cardPawn;
    public GameObject placedVisual;

    public int cost;

    public float health;
    public float damage;
    public float attackTime;
    public int range;


    public List<TypeSO> types;
}
