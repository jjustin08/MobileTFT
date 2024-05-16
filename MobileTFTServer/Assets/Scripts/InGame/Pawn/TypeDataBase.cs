using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TypeData
{
    //icon is null on server
    public Sprite icon;
    public string typeName = "Default";
    public string description = "Default";

    public List<int> amounts;
    public List<string> amountDescriptions;

    // Constructor
    public TypeData(Sprite icon, string typeName, string description, List<int> amounts, List<string> amountDescriptions)
    {
        this.icon = icon;
        this.typeName = typeName;
        this.description = description;
        this.amounts = amounts;
        this.amountDescriptions = amountDescriptions;
    }
}

public class TypeDataBase
{
    public static Dictionary<int, TypeData> Types { get; } = new Dictionary<int, TypeData>
    {
        {
            TypeIndex.Type1,
            new TypeData(null,
                typeName : "Type1",
                description: "Type1 Description",
                amounts: new List<int>() {0},
                amountDescriptions:new List<string>() {"des"})
        },
        {
            TypeIndex.Type2,
            new TypeData( null,
                typeName : "Type2",
                description: "Type2 Description",
                amounts: new List<int>() {0},
                amountDescriptions:new List<string>() {"des"}) 
        }
    };


}


static public class TypeIndex
{
    public const int Type1 = 0;
    public const int Type2 = 1;
}
