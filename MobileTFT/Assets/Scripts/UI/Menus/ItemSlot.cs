using System;
using UnityEngine;
using UnityEngine.UI;

namespace FiniteGameStudio
{
    public class ItemSlot : MonoBehaviour
    {
        public int ID;
        private Image image;
        public ItemDataSO data;
        void Awake()
        {
            image = GetComponent<Image>();
        }

        public void UpdateSlot()
        {
            if (data != null)
            {
                image.sprite = data.icon;
            }
                
        }
    }
}
