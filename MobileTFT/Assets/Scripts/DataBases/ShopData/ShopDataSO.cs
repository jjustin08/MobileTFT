using System;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteGameStudio
{
    [CreateAssetMenu(fileName = "ShopDataSO", menuName = "Scriptable Objects/ShopDataSO")]
    public class ShopDataSO : ScriptableObject
    {
        public List<ItemDataSO> items;
        private void OnEnable()
        {
            items.Clear();
            ItemDataSO[] itemArr = Resources.LoadAll<ItemDataSO>("ShopItems");
            items.AddRange(itemArr);
        }
    }
}
