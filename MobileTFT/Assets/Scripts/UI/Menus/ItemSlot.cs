using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace FiniteGameStudio
{
    public class ItemSlot : MonoBehaviour
    {
        public int ID;
        public ItemDataSO data;
        
        private Image _image;
        private TMP_Text _amountText;
        void Awake()
        {
            _image = transform.GetChild(0).GetComponent<Image>();
            _amountText = transform.GetChild(1).GetComponent<TMP_Text>();
        }

        public void UpdateSlot()
        {
            if (data != null)
            {
                _image.sprite = data.icon;
                _amountText.text = data.amount.ToString();
            }
            else
            {
                _image.sprite = data.defaultIcon;
                _amountText.text = " ";
            }
                
        }
    }
}
