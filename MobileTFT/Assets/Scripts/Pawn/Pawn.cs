using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PawnStats))]
[RequireComponent(typeof(PawnMovement))]
[RequireComponent(typeof(PawnCombat))]
[RequireComponent(typeof(PawnAI))]
public class Pawn : MonoBehaviour
{
    [SerializeField] private bool isEnemy;
    private PawnStats stats;
    private PawnMovement movement;
    private PawnCombat combat;
    private PawnInteraction interaction;
    private PawnAI aI;
    

    private void Awake()
    {
        stats = GetComponent<PawnStats>();
        movement= GetComponent<PawnMovement>();
        combat = GetComponent<PawnCombat>();
        aI = GetComponent<PawnAI>();
        interaction = GetComponentInChildren<PawnInteraction>();
    }

    public void ToggleCombat(bool toggle)
    {
        GetAI().ToggleCombat(toggle);
        GetStats().ToggleCombat(toggle);
        GetMovement().ToggleCombat(toggle);
        GetInteraction().ToggleInteraction(!toggle);
    }

    public PawnStats GetStats() { return stats; }
    public PawnMovement GetMovement() { return movement; }
    public PawnCombat GetCombat() { return combat; }
    public PawnAI GetAI() { return aI; }
    public PawnInteraction GetInteraction() { return interaction; }
    public bool IsEnemy() { return isEnemy; }


}
