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

        private int MAX_Points = 1000;
        private int _points;
        
        private void Update()
        {
            pointsText.text = _points.ToString();
            slider.value = (float)_points / MAX_Points;
        }

        public void AddPoints(int point)
        {
            if (point < 0) return;
            
            if ((_points + point) < MAX_Points)
                _points += point;
            else
                _points = MAX_Points;
        }

        public void ChangeMaxPoints(int maxPoint)
        {
            if (maxPoint < 0) return;
            
            if (_points > maxPoint)
                _points = maxPoint;
            
            MAX_Points = maxPoint;
        }
    }
}
