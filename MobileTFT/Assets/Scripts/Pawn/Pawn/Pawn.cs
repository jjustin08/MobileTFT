using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PawnStats))]
[RequireComponent(typeof(PawnMovement))]
[RequireComponent(typeof(PawnCombat))]
[RequireComponent(typeof(PawnAI))]
[RequireComponent(typeof(PawnVisual))]
public class Pawn : MonoBehaviour
{
    [SerializeField] private PawnVisual pVisual;
    [SerializeField] private PawnData pawnData;
    [SerializeField] private bool isEnemy;
    private PawnStats stats;
    private PawnMovement movement;
    private PawnCombat combat;
    private PawnInteraction interaction;
    private PawnAI aI;
   


    private void Update()
    {
        if (GetMovement().GetSlot().GetPawn() == null)
        {
            print("This should not happen");
            GetMovement().GetSlot().PlacePawn(this);
        }
    }
    public void SetPawnData(PawnData data)
    {
        pawnData = data;
        stats.CalculateStats(true);
    }

    public void SelfDestruct()
    {
        movement.GetSlot().RemovePawn();
        Destroy(gameObject);
    }
    private void Awake()
    {
        stats = GetComponent<PawnStats>();
        movement= GetComponent<PawnMovement>();
        combat = GetComponent<PawnCombat>();
        aI = GetComponent<PawnAI>();
        interaction = GetComponentInChildren<PawnInteraction>();
        pVisual = GetComponentInChildren<PawnVisual>();
    }

    public void ToggleCombat(bool toggle)
    {
        GetAI().ToggleCombat(toggle);
        GetStats().ToggleCombat(toggle);
        GetMovement().ToggleCombat(toggle);
        GetInteraction().ToggleInteraction(!toggle);
        GetInteraction().CancelDrag();
    }

    public PawnStats GetStats() { return stats; }
    public PawnMovement GetMovement() { return movement; }
    public PawnCombat GetCombat() { return combat; }
    public PawnAI GetAI() { return aI; }
    public PawnVisual GetVisual() { return pVisual; }
    public PawnInteraction GetInteraction() { return interaction; }
    public PawnData GetPawnData() { return pawnData; }
    public bool IsEnemy() { return isEnemy; }
    public void SetEnemy(bool enemy) { isEnemy = enemy; interaction.ToggleInteraction(!enemy); }


}
