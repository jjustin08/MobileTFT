using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FiniteGameStudio
{
    public class BattlePassUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text pointsText;
        [SerializeField] private Slider slider;
        
        private UserDataSO _currentUserData;

        private void Awake()
        {
            _currentUserData = GameInstance.Instance.GetUserData();
            if(_currentUserData == null)
                Debug.LogError("Incorrectly set User Data - BattlePassUI.cs");
            
            _currentUserData.GetBattlePassData().OnPointsChanged += OnPointsChanged;
        }

        private void Start()
        {
            pointsText.text = _currentUserData.GetBattlePassData().GetPoints().ToString();
            slider.value = (float)_currentUserData.GetBattlePassData().GetPoints() / _currentUserData.GetBattlePassData().GetMaxPoints();
        }

        private void OnPointsChanged(int obj)
        {
            pointsText.text = obj.ToString();
            slider.value = (float)obj / _currentUserData.GetBattlePassData().GetMaxPoints();
        }

    }
}
