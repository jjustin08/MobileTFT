using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PawnDataBase
{
    public List<PawnData> GetCharactersByCost(int cost)
    {
        return pawns.Values.Where(pawn => pawn.cost == cost).ToList();
    }
    public static Dictionary<PawnEnum, PawnData> pawns { get; } = new Dictionary<PawnEnum, PawnData>
    {
        {
            PawnEnum.Pawn1,
            new PawnData(
            pawnName: "Pawn1",
            cost: 1,
            ability: AbilityDataBase.Abilities[AbilityEnum.Ability1],
            types: new List<TypeData>() {TypeDataBase.Types[TypeEnum.Type1]},
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
            PawnEnum.Pawn2, 
            new PawnData(
            pawnName: "Pawn2",
            cost: 2,
            ability: AbilityDataBase.Abilities[AbilityEnum.Ability2],
            types: new List<TypeData>() {TypeDataBase.Types[TypeEnum.Type1]},
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

public enum PawnEnum
{
    Pawn1,
    Pawn2,
}