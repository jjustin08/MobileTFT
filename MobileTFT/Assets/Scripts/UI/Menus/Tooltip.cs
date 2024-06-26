using System;
using TMPro;
using UnityEngine;

namespace FiniteGameStudio
{
    public class Tooltip : MonoBehaviour
    {
        private static Tooltip instance;
        
        private TMP_Text _tooltipText;
        private RectTransform _bgRectTransform;
        [SerializeField] private RectTransform canvansRectTransform;
        
        private void Awake()
        {
            instance = this;
            _bgRectTransform = transform.Find("BG").GetComponent<RectTransform>();
            _tooltipText = transform.Find("TooltipText").GetComponent<TMP_Text>();
            HideTooltip();
        }

        private void ShowTooltip(string tooltipString, Vector2 clickPosition)
        {
            _bgRectTransform.gameObject.SetActive(true);
            _tooltipText.gameObject.SetActive(true);

            _tooltipText.text = tooltipString;
            
            // Flexible Background
            float textPaddingSize = 4f;
            Vector2 bgSize = new Vector2(_tooltipText.preferredWidth + textPaddingSize * 2f,
                _tooltipText.preferredHeight + textPaddingSize * 2f);
            _bgRectTransform.sizeDelta = bgSize;

            // Set Position and make it not to cross a board
            transform.position = clickPosition;
            float bgBoxRightXPosition = clickPosition.x + _bgRectTransform.sizeDelta.x;
            if (bgBoxRightXPosition > canvansRectTransform.rect.width)
            {
                float newX = canvansRectTransform.rect.width - _bgRectTransform.sizeDelta.x;
                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }

        private void HideTooltip()
        {
            _bgRectTransform.gameObject.SetActive(false);
            _tooltipText.gameObject.SetActive(false);
        }

        public static void ShowTooltip_Static(string tooltipString, Vector2 clickPosition)
        {
            instance.ShowTooltip(tooltipString, clickPosition);
        }
        
        public static void HideTooltip_Static()
        {
            instance.HideTooltip();
        }
    }
}
