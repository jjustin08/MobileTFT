using System.Collections.Generic;
using UnityEngine;

namespace FiniteGameStudio
{
    [CreateAssetMenu(fileName = "InventoryDataSO", menuName = "Scriptable Objects/InventoryDataSO")]
    public class InventoryDataSO : ScriptableObject
    {
        public List<ItemDataSO> items;
    }
}
