using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FiniteGameStudio
{
    public class ItemSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public int ID;
        public ItemDataSO data;
        
        private Image _image;
        private TMP_Text _amountText;
        
        private float tooltipPositionOffsetX = 100f;
        private float tooltipPositionOffsetY = 100f;
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
        public void OnPointerDown(PointerEventData eventData)
        {
            if (data != null)
            {
                Vector2 position = new Vector2(eventData.position.x + tooltipPositionOffsetX,
                    eventData.position.y - tooltipPositionOffsetY);
                Tooltip.ShowTooltip_Static(data.name, position);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Tooltip.HideTooltip_Static();
        }
    }
}
