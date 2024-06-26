using System;
using System.Collections.Generic;
using UnityEngine;

namespace FiniteGameStudio
{
    [CreateAssetMenu(fileName = "BattlePassDataSO", menuName = "Scriptable Objects/BattlePassDataSO")]
    public class BattlePassDataSO : ScriptableObject
    {
        [SerializeField] private int _points;
        [SerializeField] private int _maxPoints;
        [SerializeField] private bool _isPurchased;
        [SerializeField] private bool _isCompleted;
        [SerializeField] private List<ItemDataSO> _awardItems;
        public Action<int> OnPointsChanged;
        
        public int GetPoints() { return _points; }
        public int GetMaxPoints() { return _maxPoints; }
        public bool GetIsPurchased() { return _isPurchased; }
        public bool GetIsCompleted() { return _isCompleted; }
        public List<ItemDataSO> GetAwardItems() { return _awardItems; }

        private void OnEnable()
        {
            _points = 0;
            _awardItems = new List<ItemDataSO>();
            ItemDataSO[] itemArr = Resources.LoadAll<ItemDataSO>("BattlePassItems");
            _awardItems.AddRange(itemArr);
        }
        
        public int GetCheckPointIdxByPoints()
        {
            float fNum = (float)_points / _maxPoints;
            return (int)((fNum * 10) - 1);
        }
        public void AddPoints(int point)
        {
            if (point < 0) return;
            
            if ((_points + point) < _maxPoints)
                _points += point;
            else
                _points = _maxPoints;
            
            OnPointsChanged?.Invoke(_points);
        }
        
        public void SetPoints(int point)
        {
            if (point < 0 || point > _maxPoints) return;
            
            _points = point;
            
            OnPointsChanged?.Invoke(_points);
        }
        
        public void ChangeMaxPoints(int maxPoint)
        {
            if (maxPoint < 0) return;
            
            if (_points > maxPoint)
                _points = maxPoint;
            
            _maxPoints = maxPoint;
        }
    }
}
