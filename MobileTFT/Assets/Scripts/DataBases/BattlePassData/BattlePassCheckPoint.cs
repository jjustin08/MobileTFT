using System;
using UnityEngine;
using UnityEngine.UI;

namespace FiniteGameStudio
{
    public class BattlePassCheckPoint : MonoBehaviour
    {
        private Image _iconImage;
        private Sprite _defaultSprite;
        [SerializeField] private Sprite _achievedSprite;
        private ItemDataSO _awardItem;
        [SerializeField] private bool _isAchieved;

        private void Awake()
        {
            _iconImage = GetComponent<Image>();
            _defaultSprite = _iconImage.sprite;
        }

        public void SetAwardItem(ItemDataSO itemData)
        {
            _awardItem = itemData;
        }

        public ItemDataSO GetAwardItem()
        {
            if (_isAchieved)
                return _awardItem;
            
            return null;
        }

        public void SetIsAchieved()
        {
            _isAchieved = true;
            _iconImage.sprite = _achievedSprite;
        }

        public void ResetIsAchieved()
        {
            _isAchieved = false;
            _iconImage.sprite = _defaultSprite;
        }

        public bool IsAchieved()
        {
            return _isAchieved;
        }
    }
}
