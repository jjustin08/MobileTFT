using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityDataBase
{
    public static Dictionary<AbilityEnum, AbilityData> Abilities { get; } = new Dictionary<AbilityEnum, AbilityData>
    {
        { AbilityEnum.Ability1, new AbilityData("Ability1") },
        { AbilityEnum.Ability2, new AbilityData("Ability2") }
    };
}

public enum AbilityEnum
{
    Ability1,
    Ability2,
}
