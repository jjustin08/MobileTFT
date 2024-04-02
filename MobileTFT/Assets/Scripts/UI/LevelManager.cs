using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelIcon;
    [SerializeField] private Slider levelSlider;

    
    private int maxExp = 10;
    private int maxMaxExp = 60;
    private int currentExp = 0;

    private void Start()
    {
        UIUpdate();
    }

    private void UIUpdate()
    {
        int level = 1;
        float tempExp = currentExp;
        while(tempExp >= maxExp)
        {
            level++;
            tempExp -= maxExp;
        }
        levelIcon.text = level.ToString();
        levelSlider.value = (tempExp/maxExp);

        Player.Instance.GetPlayerStats().SetPlayerLevel(level);
    }

    public void GainExp(int amount)
    {
        if(currentExp + amount <= maxMaxExp)
        {
            if(CashManager.Instance.RemoveCash(amount))
            {
                currentExp += amount;
                UIUpdate();
            }
        }
        else
        {
            int tempCash = maxMaxExp - currentExp;
            if (CashManager.Instance.RemoveCash(tempCash))
            {
                currentExp += tempCash;
                UIUpdate();
            }
        }
        
    }
}
