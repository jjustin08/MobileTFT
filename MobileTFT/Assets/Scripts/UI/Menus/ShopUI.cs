using System.Collections.Generic;
using UnityEngine;

namespace FiniteGameStudio
{
    public class ShopUI : MonoBehaviour
    {
        private List<ItemSlot> _itemSlots;
        private GameObject _contents;
        
        public ShopDataSO _shopData;
        
        void Start()
        {
            Init();
        }
        
        public void ChangeShopData(ShopDataSO shopDataSo)
        {
            _shopData = shopDataSo;
        }

        private void Init()
        {
            _itemSlots = new List<ItemSlot>();
            _contents = transform.GetChild(0).transform.GetChild(0).gameObject; // Contents gameObject

            int count = 0;
            for (int i = 0; i < _contents.transform.childCount; i++)
            {
                for (int j = 0; j < _contents.transform.GetChild(i).transform.childCount; j++)
                {
                    _itemSlots.Add(_contents.transform.GetChild(i).transform.GetChild(j).GetComponent<ItemSlot>());
                    _itemSlots[count].ID = count;
                }
            }

            for (int i = 0; i < _shopData.items.Count; i++)
            {
                _itemSlots[i].data = _shopData.items[i];
                _itemSlots[i].UpdateSlot();
            }
        }
    }
}
