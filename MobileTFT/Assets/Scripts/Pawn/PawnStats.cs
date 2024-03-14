using UnityEngine;

public class PawnStats : MonoBehaviour
{
    private Pawn parentPawn;

    private float health;
    private float currentHealth;
    private float damage;
    private float attackTime;
    private int range;

    private void Start()
    {
        parentPawn = GetComponent<Pawn>();
        PawnSO SO = parentPawn.GetPawnSO();
  
        health = SO.health;
        currentHealth = SO.health;
        damage = SO.damage;
        attackTime = SO.attackTime;
        range = SO.range;
    }


    public float GetAttackTime(){return attackTime;}
    public float GetCurrentHealth() { return currentHealth;}
    public float GetDamage() { return damage;}
    public int GetRange() { return range; }


    public void ToggleCombat(bool toggle)
    {
        if (!toggle)
        {
            currentHealth = health;
        }
    }
    public void SetCurrentHealth(float newHealth)
    {
        currentHealth = newHealth;
    }
}
