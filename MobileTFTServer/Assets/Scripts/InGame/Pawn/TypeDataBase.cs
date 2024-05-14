using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TypeDataBase
{
    public static Dictionary<TypeEnum, TypeData> Types { get; } = new Dictionary<TypeEnum, TypeData>
    {
        { 
            TypeEnum.Type1,
            new TypeData(
                typeName : "Type1",
                description: "Type1 Description",
                amounts: new List<int>() {0},
                amountDescriptions:new List<string>() {"des"})
        },
        { 
            TypeEnum.Type2,
            new TypeData(
                typeName : "Type2",
                description: "Type2 Description",
                amounts: new List<int>() {0},
                amountDescriptions:new List<string>() {"des"}) 
        }
    };


}

public enum TypeEnum
{
    Type1,
    Type2,
}

