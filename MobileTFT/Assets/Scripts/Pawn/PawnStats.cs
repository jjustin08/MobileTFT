using UnityEngine;

public class PawnStats : MonoBehaviour
{
    private Pawn parentPawn;

    [SerializeField]private int killCount;
    private float health;
    private float currentHealth;
    private float damage;
    private float attackTime;
    private int range;

    private void Start()
    {
        parentPawn = GetComponent<Pawn>();
        CalculateStats();
    }


    public float GetAttackTime(){return attackTime;}
    public float GetCurrentHealth() { return currentHealth;}
    public float GetDamage() { return damage;}
    public int GetRange() { return range; }


    public void ToggleCombat(bool toggle)
    {
        if (!toggle)
        {
            SetCurrentHealth(health);
        }
    }
    public void SetCurrentHealth(float newHealth)
    {
        currentHealth = newHealth;

        // error here
        parentPawn.GetVisual().UpdateHealthBar(health,currentHealth);
    }

    public void AddKillToCount()
    {
        killCount++;
        CalculateStats();
        parentPawn.GetVisual().SetKillCountText(killCount);
    }

    public int GetKillCount()
    {
        return killCount;
    }

    public void SetKillCount(int k)
    {
        killCount = k;
        GetComponent<Pawn>().GetVisual().SetKillCountText(killCount);
    }


    // will need to refactor this later
    private void CalculateStats()
    {
        PawnSO SO = parentPawn.GetPawnSO();
        foreach(Type type in SO.types)
        {
            //get how many of this type
            int amount = 0;
            foreach(Pawn p in GridUtil.Instance.GetAllPawns(true))
            {
                if(p.GetPawnSO().types.Contains(type))
                {
                    amount++;
                }
            }
            
            type.Effect(parentPawn, amount);
        }

        health = SO.health;
        damage = SO.damage;
        attackTime = SO.attackTime;
        range = SO.range;

        for (int i = 0; i < killCount; i++) 
        {
            // this will change depending on what type etc
            damage += 1;
            health += 2;
        }
    }
}
