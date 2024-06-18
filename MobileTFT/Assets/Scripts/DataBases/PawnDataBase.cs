using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PawnData
{
    // always null in server (only stored on client)
    public GameObject placedPawn;
    public GameObject cardVisual;
    // Common properties
    public int index;
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
    public PawnData(GameObject placedPawn, GameObject cardVisual,
                         int index, string pawnName, int cost, AbilityData ability, List<TypeData> types,
                         float health, float mana, float damage, float attackTime, int range,
                         float health2, float mana2, float damage2, float attackTime2, int range2,
                         float health3, float mana3, float damage3, float attackTime3, int range3)
    {
        this.index = index;
        this.placedPawn = placedPawn;
        this.cardVisual = cardVisual;
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

public class PawnDataBase
{
    public List<PawnData> GetCharactersByCost(int cost)
    {
        return pawns.Values.Where(pawn => pawn.cost == cost).ToList();
    }
    public static Dictionary<int, PawnData> pawns { get; } = new Dictionary<int, PawnData>
    {
        {
            PawnIndex.Pawn1,
            new PawnData(
            placedPawn: Resources.Load<GameObject>("PlacedPawns/0"),
            cardVisual: Resources.Load<GameObject>("CardVisual/0"),
            PawnIndex.Pawn1,
            pawnName: "Pawn1",
            cost: 0,
            ability: AbilityDataBase.Abilities[AbilityIndex.Ability1],
            types: new List<TypeData>() {TypeDataBase.Types[TypeIndex.Type1]},
            health: 100,
            mana: 50,
            damage: 20,
            attackTime: 2.0f,
            range: 5,
            health2: 150,
            mana2: 75,
            damage2: 30,
            attackTime2: 1.5f,
            range2: 7,
            health3: 200,
            mana3: 100,
            damage3: 40,
            attackTime3: 1.0f,
            range3: 10)
        },
        {
            PawnIndex.Pawn2,
            new PawnData(
            placedPawn: Resources.Load<GameObject>("PlacedPawns/0"),
            cardVisual: Resources.Load<GameObject>("CardVisual/0"),
            PawnIndex.Pawn2,
            pawnName: "Pawn2",
            cost: 0,
            ability: AbilityDataBase.Abilities[AbilityIndex.Ability2],
            types: new List<TypeData>() {TypeDataBase.Types[TypeIndex.Type1]},
            health: 120,
            mana: 60,
            damage: 25,
            attackTime: 1.8f,
            range: 6,
            health2: 180,
            mana2: 90,
            damage2: 35,
            attackTime2: 1.3f,
            range2: 8,
            health3: 240,
            mana3: 120,
            damage3: 45,
            attackTime3: 0.8f,
            range3: 12)
        }
    };
}


static public class PawnIndex
{
    public const int Pawn1 = 0;
    public const int Pawn2 = 1;
}