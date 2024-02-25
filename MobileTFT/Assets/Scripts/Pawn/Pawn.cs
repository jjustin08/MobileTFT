using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PawnStats))]
[RequireComponent(typeof(PawnMovement))]
[RequireComponent(typeof(PawnCombat))]
public class Pawn : MonoBehaviour
{
    [SerializeField] private bool isEnemy;
    private PawnStats stats;
    private PawnMovement movement;
    private PawnCombat combat;

    private void Awake()
    {
        stats = GetComponent<PawnStats>();
        movement= GetComponent<PawnMovement>();
        combat = GetComponent<PawnCombat>();
    }

    public PawnStats GetStats() { return stats; }
    public PawnMovement GetMovement() { return movement; }
    public PawnCombat GetCombat() { return combat; }
    public bool IsEnemy() { return isEnemy; }
}
