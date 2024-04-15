using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelIcon;
    [SerializeField] private Slider levelSlider;


    bool inCombat = false;


    // put this inside player instead
    private int maxExp = 10;
    private int maxMaxExp = 60;
    private int currentExp = 0;

    private void Start()
    {
        UIUpdate();
    }

    public void UIUpdate()
    {
        int level = 1;
        float tempExp = currentExp;
        while(tempExp >= maxExp)
        {
            level++;
            tempExp -= maxExp;
        }
        
        levelSlider.value = (tempExp/maxExp);

        Player.Instance.GetPlayerStats().SetPlayerLevel(level);

        //levelIcon.text = level.ToString();
        // lets do it for how many pawns you can have/
        // also need to turn off while in combat...

        if(!inCombat)
        {
            int pawnCount = GridUtil.Instance.GetAllPawns(true).Count;

            string levelIconText = pawnCount +"/" + level;

            levelIcon.text = levelIconText;
        }

    }

    public void GainExp(int amount)
    {
        if(currentExp + amount <= maxMaxExp)
        {
            if (Player.Instance.GetPlayerStats().RemoveCash(amount))
            {
                currentExp += amount;
                UIUpdate();
            }
        }
        else
        {
            int tempCash = maxMaxExp - currentExp;
            if (Player.Instance.GetPlayerStats().RemoveCash(tempCash))
            {
                currentExp += tempCash;
                UIUpdate();
            }
        }
    }

    public void ToggleCombat(bool toggle)
    {
        inCombat = toggle;
        if (!toggle)
        {
            levelIcon.gameObject.SetActive(true);
            UIUpdate();
        }
        else
        {
            levelIcon.gameObject.SetActive(false);
        }
    }


}
