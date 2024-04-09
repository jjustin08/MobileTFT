using System.Collections.Generic;
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

    private float moveTime = 0.5f;

    private int deathCount;

    private float killCountDamageModifier = 1.0f;
    private float killCountHealthModifier = 1.0f;

    private int killCountCashBonus = 0;

    private void Start()
    {
        parentPawn = GetComponent<Pawn>();
        CalculateStats(true);
    }


    public float GetAttackTime(){return attackTime;}
    public float GetCurrentHealth() { return currentHealth;}
    public float GetDamage() { return damage;}
    public int GetRange() { return range; }
    public float GetMoveTime() { return moveTime;}

    public int GetDeathCount() {  return deathCount; }

    public void SetKillCountCashBonus(int p)
    {
        killCountCashBonus = p;
    }
    public void SetDeathCount(int count)
    {
        // idk if i want a max or not
        if(count>= 10)
        {
            deathCount = 10;
        }
        else
        {
            deathCount = count;
        }
        
    }
    public void SetMoveTime(float t)
    {
        moveTime = t;
    }

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

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    public void SetDamageTime(float newDamageTime)
    {
        attackTime = newDamageTime;
    }
    public void SetAttackRange(int newAttackRange)
    {
        range = newAttackRange;
    }
    public void AddKillToCount()
    {
        // viking kill cash bonus
        int ran = Random.Range(0, 100);

        if (ran < killCountCashBonus)
        {
            CashManager.Instance.GainCash(1);
        }

        if (killCount >= 10)
        {
            return;
        }

        killCount++;
        for (int i = 0; i < killCount; i++)
        {
            // this will change depending on what type etc
            damage += 1 * killCountDamageModifier;
            health += 1 * killCountHealthModifier;
            currentHealth += 1 * killCountHealthModifier;
        }
        parentPawn.GetVisual().SetKillCountText(killCount);


        
    }

    public int GetKillCount()
    {
        return killCount;
    }

    public void SetKillCount(int k)
    {
        if(k >= 10)
        {
            killCount = 10;
        }
        else
        {
            killCount = k;
        }
       
        GetComponent<Pawn>().GetVisual().SetKillCountText(killCount);
    }

    public void SetKillCountDamageModifier(float m)
    {
        killCountDamageModifier = m;
    }
    public void SetKillCountHealthModifier(float m)
    {
        killCountHealthModifier = m;
    }


    public void CalculateStats(bool affectCurrentHealth)
    {
        //print("stats calculate");
        PawnSO SO = parentPawn.GetPawnSO();
        

        health = SO.health;
       
        damage = SO.damage;
        attackTime = SO.attackTime;
        range = SO.range;

        for (int i = 0; i < killCount; i++)
        {
            // this will change depending on what type etc
            damage += 1 * killCountDamageModifier;
            health += 1 * killCountHealthModifier;
        }


        if (affectCurrentHealth)
        {
            currentHealth = health;
        }

        foreach (Type type in SO.types)
        {
            //get how many of this type
            int amount = 0;
            List<PawnSO> countedPawns = new List<PawnSO>();
            foreach (Pawn p in GridUtil.Instance.GetAllPawns(true))
            {
                if (countedPawns.Contains(p.GetPawnSO()))
                {
                    continue;
                }

                countedPawns.Add(p.GetPawnSO());
                if (p.GetPawnSO().types.Contains(type))
                {
                    amount++;
                }
            }

            type.AffectStats(parentPawn, amount);
        }
    }
}
