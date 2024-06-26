using System;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteGameStudio
{
    public class BattlePassSystem : MonoBehaviour
    {
        [SerializeField] private List<BattlePassCheckPoint> _checkPoints;
        private void Start()
        {
            Init();
        }

        private void Init()
        {
            GameInstance.Instance.GetUserData().GetBattlePassData().OnPointsChanged += OnPointsChanged;
            
            if(_checkPoints.Count != 10)
                Debug.LogError("Incorrectly set Battle Pass CheckPoints - BattlePassSystem.cs");

            for (int i = 0; i < _checkPoints.Count; i++)
            {
                _checkPoints[i].SetAwardItem(GameInstance.Instance.GetUserData().GetBattlePassData().GetAwardItems()[i]);
            }
            
            UpdatedAchievedCheckPoints();
        }

        private void OnPointsChanged(int obj)
        {
            UpdatedAchievedCheckPoints();
        }

        private void UpdatedAchievedCheckPoints()
        {
            int idx = GameInstance.Instance.GetUserData().GetBattlePassData().GetCheckPointIdxByPoints();
            
            for (int i = 0; i < _checkPoints.Count; i++)
            {
                if(i <= idx)
                    _checkPoints[i].SetIsAchieved();
                else
                    _checkPoints[i].ResetIsAchieved();
                
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            GameInstance.Instance.GetUserData().GetBattlePassData().AddPoints(50);
        }

    }
}
