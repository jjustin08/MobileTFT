using System.Collections.Generic;
using UnityEngine;

namespace FiniteGameStudio
{
    public class InventoryUI : MonoBehaviour
    {
        private List<ItemSlot> _itemSlots;
        private GameObject _contents;
        
        //TODO: Need to change it once accounting system is done.
        public InventoryDataSO _userInventory;
        
        void Start()
        {
            Init();
        }
        
        public void UserInventoryData(InventoryDataSO inventoryDataSo)
        {
            _userInventory = inventoryDataSo;
        }

        private void Init()
        {
            _itemSlots = new List<ItemSlot>();
            _contents = transform.GetChild(0).transform.GetChild(0).gameObject;

            int count = 0;
            for (int i = 0; i < _contents.transform.childCount; i++)
            {
                for (int j = 0; j < _contents.transform.GetChild(i).transform.childCount; j++)
                {
                    _itemSlots.Add(_contents.transform.GetChild(i).transform.GetChild(j).GetComponent<ItemSlot>());
                    _itemSlots[count].ID = count;
                }
            }

            //TODO: Need to change it once accounting system is done.
            //UserInventoryData();

            for (int i = 0; i < _userInventory.items.Count; i++)
            {
                _itemSlots[i].data = _userInventory.items[i];
                _itemSlots[i].UpdateSlot();
            }
        }
    }
}
