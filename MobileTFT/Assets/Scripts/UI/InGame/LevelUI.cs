using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelIcon;
    [SerializeField] private TextMeshProUGUI levelCostText;

    bool inCombat = false;

    private void Start()
    {
        UIUpdate(1);
    }

    public void SetLevelCostUI(string cost)
    {
        levelCostText.text = cost;   
    }

    public void UIUpdate(int newLevel)
    {
        int level = newLevel;

        if(!inCombat)
        {
            int pawnCount = GridUtil.Instance.GetAllPawns(true).Count;

            string levelIconText = pawnCount +"/" + level;

            levelIcon.text = levelIconText;
        }

    }

    public void ToggleCombat(bool toggle)
    {
        inCombat = toggle;
        if (!toggle)
        {
            levelIcon.gameObject.SetActive(true);
        }
        else
        {
            levelIcon.gameObject.SetActive(false);
        }

        UIUpdate(Player.Instance.GetPlayerStats().GetPlayerLevel());
    }
}
