using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TypeDataBase
{
    public static Dictionary<TypeEnum, TypeData> Types { get; } = new Dictionary<TypeEnum, TypeData>
    {
        { TypeEnum.Type1, new TypeData("Type1") },
        { TypeEnum.Type2, new TypeData("Type2") }
    };


}

public enum TypeEnum
{
    Type1,
    Type2,
}

