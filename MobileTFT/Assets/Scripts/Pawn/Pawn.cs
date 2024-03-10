using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PawnStats))]
[RequireComponent(typeof(PawnMovement))]
[RequireComponent(typeof(PawnCombat))]
[RequireComponent(typeof(AI))]
public class Pawn : MonoBehaviour
{
    [SerializeField] private bool isEnemy;
    private PawnStats stats;
    private PawnMovement movement;
    private PawnCombat combat;
    private AI aI;

    private void Awake()
    {
        stats = GetComponent<PawnStats>();
        movement= GetComponent<PawnMovement>();
        combat = GetComponent<PawnCombat>();
        aI = GetComponent<AI>();
    }

    public PawnStats GetStats() { return stats; }
    public PawnMovement GetMovement() { return movement; }
    public PawnCombat GetCombat() { return combat; }
    public AI GetAI() { return aI; }
    public bool IsEnemy() { return isEnemy; }


}
