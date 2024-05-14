using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TypeData
{
    public string typeName = "Default";
    public string description = "Default";

    public List<int> amounts;
    public List<string> amountDescriptions;

    // Constructor
    public TypeData(string typeName, string description, List<int> amounts, List<string> amountDescriptions)
    {
        this.typeName = typeName;
        this.description = description;
        this.amounts = amounts;
        this.amountDescriptions = amountDescriptions;
    }
}


