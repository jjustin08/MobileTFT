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
            Vector2 textBoxSize = new Vector2(_tooltipText.preferredWidth,_tooltipText.rectTransform.sizeDelta.y);
            
            float textPaddingSize = 4f;
            Vector2 bgSize = new Vector2(_tooltipText.preferredWidth + textPaddingSize * 2f,
                _tooltipText.rectTransform.sizeDelta.y + textPaddingSize * 2f);
            
            _bgRectTransform.sizeDelta = bgSize;
            _tooltipText.rectTransform.sizeDelta = textBoxSize;

            transform.position = clickPosition;
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
