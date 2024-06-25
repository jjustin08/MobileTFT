using System.Collections.Generic;
using UnityEngine;

public class PawnStats : MonoBehaviour
{
    private Pawn parentPawn;

    private int starCount = 1;

    private int killCount;
    private float health;
    private float mana;
    private float currentMana;
    private float currentHealth;
    private float damage;
    private float attackTime;
    private int range;

    private float moveTime = 0.5f;

    private float manaGain = 1f;

    private int deathCount;

    private float killCountDamageModifier = 0.5f;
    private float killCountHealthModifier = 0.5f;

    private int killCountCashBonus = 0;

    private void Awake()
    {
        parentPawn = GetComponent<Pawn>();
    }

    public int GetStarCount() {  return starCount; }
    public float GetAttackTime(){return attackTime;}
    public float GetCurrentHealth() { return currentHealth;}
    public float GetDamage() { return damage;}
    public int GetRange() { return range; }
    public float GetMana() { return mana; }
    public float GetMoveTime() { return moveTime;}

    public int GetDeathCount() {  return deathCount; }

    public void SetStarCount(int c)
    {
        starCount = c;
        parentPawn.GetVisual().SetStarCountImage(c);
        CalculateStats(true);
    }
    public void SetKillCountCashBonus(int p)
    {
        killCountCashBonus = p;
    }
    public void SetDeathCount(int count)
    {
        deathCount = count;
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
            SetCurrentMana(0);
        }
    }
    public void SetCurrentHealth(float newHealth)
    {
        currentHealth = newHealth;

        // error here
        parentPawn.GetVisual().UpdateHealthBar(health,currentHealth);
    }

    public void SetCurrentMana(float newMana)
    {
        currentMana = newMana;

        parentPawn.GetVisual().UpdateManaBar(mana,currentMana);
    }

    public void AddMana()
    {
        currentMana += manaGain;

        parentPawn.GetVisual().UpdateManaBar(mana, currentMana);
    }
    public bool IsManaFull()
    {
        if (currentMana > mana)
        {
            return true;
        }
        return false;
    }

    public float GetCurrentMana()
    {
        return currentMana;
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
            Player.Instance.GetPlayerStats().GainCash(1);
        }

        if (starCount == 3)
        {
            if (killCount >= 15)
            {
                return;
            }
        }
        else if (starCount == 2)
        {
            if (killCount >= 10)
            {
                return;
            }
        }
        else
        {
            if (killCount >= 5)
            {
                return;
            }
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
        if(starCount == 3)
        {
            if (k >= 15)
            {
                killCount = 15;
            }
            else
            {
                killCount = k;
            }
        }
        else if(starCount == 2)
        {
            if (k >= 10)
            {
                killCount = 10;
            }
            else
            {
                killCount = k;
            }
        }
        else
        {
            if (k >= 5)
            {
                killCount = 5;
            }
            else
            {
                killCount = k;
            }
        }
        

        for (int i = 0; i < killCount; i++)
        {
            // this will change depending on what type
            damage += 1 * killCountDamageModifier;
            health += 1 * killCountHealthModifier;
            currentHealth += 1 * killCountHealthModifier;
        }

        parentPawn.GetVisual().SetKillCountText(killCount);
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
        // TODO: refactor this
        PawnData data = parentPawn.GetPawnData();

        switch (starCount)
        {
            case 1:
                health = data.health;
                mana = data.mana;
                damage = data.damage;
                attackTime = data.attackTime;
                range = data.range;
                break;
            case 2:
                health = data.health2;
                mana = data.mana2;
                damage = data.damage2;
                attackTime = data.attackTime2;
                range = data.range2;
                break;
            case 3:
                health = data.health3;
                mana = data.mana3;
                damage = data.damage3;
                attackTime = data.attackTime3;
                range = data.range3;
                break;
        }



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

        foreach (TypeData type in data.types)
        {
            //get how many of this type
            int amount = 0;
            List<PawnData> countedPawns = new List<PawnData>();
            foreach (Pawn p in GridUtil.Instance.GetAllPawns(!parentPawn.IsEnemy()))
            {
                if (countedPawns.Contains(p.GetPawnData()))
                {
                    continue;
                }

                countedPawns.Add(p.GetPawnData());
                if (p.GetPawnData().types.Contains(type))
                {
                    amount++;
                }
            }

            // TODO: refactor stats
            //type.AffectStats(parentPawn, amount);
        }
    }
}
