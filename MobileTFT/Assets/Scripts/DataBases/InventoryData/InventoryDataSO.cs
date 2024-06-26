using System;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteGameStudio
{
    [CreateAssetMenu(fileName = "InventoryDataSO", menuName = "Scriptable Objects/InventoryDataSO")]
    public class InventoryDataSO : ScriptableObject
    {
        public List<ItemDataSO> items;

        private void OnEnable()
        {
            items = new List<ItemDataSO>();
        }

        public void StoreItem(ItemDataSO newItem)
        {
            // Has the same Item, Add amounts
            if(items.Count > 0)
            foreach (ItemDataSO item in items)
            {
                if (item.name == newItem.name)
                {
                    item.amount += newItem.amount;
                    return;
                }
            }
            
            items.Add(newItem);
        }
    }
}
