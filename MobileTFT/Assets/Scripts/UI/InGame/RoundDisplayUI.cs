using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundDisplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private Slider timerSlider;


    public void UpdateTimer(float timer, float timerMax)
    {
        timerSlider.value = timer / timerMax;
    }

    public void UpdateText(string text)
    {
        textDisplay.text = text;
    }
}
