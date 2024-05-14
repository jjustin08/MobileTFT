using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnData
{
    // Common properties
    public PawnEnum pawnEnum;
    public string pawnName;
    public int cost;
    public AbilityData ability;
    public List<TypeData> types;

    // 1 Star stats
    public float health;
    public float mana;
    public float damage;
    public float attackTime;
    public int range;

    // 2 Star stats
    public float health2;
    public float mana2;
    public float damage2;
    public float attackTime2;
    public int range2;

    // 3 Star stats
    public float health3;
    public float mana3;
    public float damage3;
    public float attackTime3;
    public int range3;

    // Constructor
    public PawnData(string pawnName, int cost, AbilityData ability, List<TypeData> types,
                         float health, float mana, float damage, float attackTime, int range,
                         float health2, float mana2, float damage2, float attackTime2, int range2,
                         float health3, float mana3, float damage3, float attackTime3, int range3)
    {
        this.pawnName = pawnName;
        this.cost = cost;
        this.ability = ability;
        this.types = types;
        this.health = health;
        this.mana = mana;
        this.damage = damage;
        this.attackTime = attackTime;
        this.range = range;
        this.health2 = health2;
        this.mana2 = mana2;
        this.damage2 = damage2;
        this.attackTime2 = attackTime2;
        this.range2 = range2;
        this.health3 = health3;
        this.mana3 = mana3;
        this.damage3 = damage3;
        this.attackTime3 = attackTime3;
        this.range3 = range3;
    }
}
