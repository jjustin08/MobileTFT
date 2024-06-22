using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnStats
{
    private PawnData data;
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

    public PawnStats(PawnData pawnData)
    {
        //set up all pawn data hc
        data = pawnData; 
        CalculateStats(true);
    }


    public void CalculateStats(bool affectCurrentHealth)
    {
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
            //TODO set up types
            //get how many of this type
            //int amount = 0;
            //List<PawnSO> countedPawns = new List<PawnSO>();
            //foreach (Pawn p in GridUtil.Instance.GetAllPawns(!parentPawn.IsEnemy()))
            //{
            //    if (countedPawns.Contains(p.GetPawnSO()))
            //    {
            //        continue;
            //    }

            //    countedPawns.Add(p.GetPawnSO());
            //    if (p.GetPawnSO().types.Contains(type))
            //    {
            //        amount++;
            //    }
            //}

            //type.AffectStats(parentPawn, amount);
        }
    }

    public int GetRange()
    {
        return range;
    }
    public float GetDamage()
    {
        return damage;
    }
    public float GetHealth()
    { return health; }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }

    public bool IsManaFull()
    {
        if (currentMana > mana)
        {
            return true;
        }
        return false;
    }

    public void SetCurrentMana(float newMana)
    {
        currentMana = newMana;
    }

    public void AddMana(float addAmount)
    {
        currentMana += addAmount;   
    }
}
