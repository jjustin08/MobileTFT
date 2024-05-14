using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeData
{
    public Sprite icon;

    public TypeData(Sprite icon)
    {
        this.icon = icon;
    }
}


public static class TypeDataBase
{
    public static Dictionary<TypeEnum, TypeData> pawns { get; } = new Dictionary<TypeEnum, TypeData>
    {
        {
            TypeEnum.Type1,
            new TypeData(
            icon: Resources.Load<Sprite>("TypeIcons/1"))
        },
        {
            TypeEnum.Type2,
            new TypeData(
            icon: Resources.Load<Sprite>("TypeIcons/2"))
        }
    };
}


public enum TypeEnum
{
    Type1,
    Type2,
}