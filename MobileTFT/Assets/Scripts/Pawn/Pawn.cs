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
    [SerializeField] private PawnSO pawnSO;
    [SerializeField] private bool isEnemy;
    private PawnStats stats;
    private PawnMovement movement;
    private PawnCombat combat;
    private PawnInteraction interaction;
    private PawnAI aI;
    private PawnVisual pVisual;

    public void SetPawnSO(PawnSO SO)
    {
        pawnSO = SO;
        pVisual.SetVisual(Instantiate(SO.placedVisual, transform));
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
        GetInteraction().ToggleInteraction(!isEnemy);
    }

    public PawnStats GetStats() { return stats; }
    public PawnMovement GetMovement() { return movement; }
    public PawnCombat GetCombat() { return combat; }
    public PawnAI GetAI() { return aI; }
    public PawnVisual GetVisual() { return pVisual; }
    public PawnInteraction GetInteraction() { return interaction; }
    public PawnSO GetPawnSO() { return pawnSO; }
    public bool IsEnemy() { return isEnemy; }
    public void SetEnemy(bool enemy) { isEnemy = enemy; interaction.ToggleInteraction(!enemy); }


}
