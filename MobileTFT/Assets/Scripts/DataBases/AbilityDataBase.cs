using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbilityData : MonoBehaviour
{
    public string abilityName;

    public AbilityData(string abilityName)
    {
        this.abilityName = abilityName;
    }
}
public class AbilityDataBase : MonoBehaviour
{
    public static Dictionary<int, AbilityData> Abilities { get; } = new Dictionary<int, AbilityData>
    {
        { AbilityIndex.Ability1, new AbilityData("Ability1") },
        { AbilityIndex.Ability2, new AbilityData("Ability2") }
    };
}



static public class AbilityIndex
{
    public const int Ability1 = 0;
    public const int Ability2 = 1;
}
