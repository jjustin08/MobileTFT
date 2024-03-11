using UnityEngine;

public class PawnStats : MonoBehaviour
{
    // TODO get base stats from scriptible object
    [SerializeField] private float health;
    [SerializeField] private float currentHealth;
    [SerializeField] private float damage;
    [SerializeField] private float attackTime;
    [SerializeField] private int range;



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
