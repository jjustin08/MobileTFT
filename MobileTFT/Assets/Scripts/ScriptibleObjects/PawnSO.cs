using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pawn")]
public class PawnSO : ScriptableObject
{
    [Header("Prefabs")]
    public Pawn placedPawn;
    public GameObject placedVisual;
    public Card cardVisual;

    [Header("Common")]
    public int cost;
    public List<TypeSO> types;

    [Header("1 Star stats")]
    public float health;
    public float damage;
    public float attackTime;
    public int range;

    [Header("2 Star stats")]
    public float health2;
    public float damage2;
    public float attackTime2;
    public int range2;

    [Header("3 Star stats")]
    public float health3;
    public float damage3;
    public float attackTime3;
    public int range3;

   
}
