using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerStats : MonoBehaviour
{
    // Health
    [SerializeField] private HealthUI healthUI;
    private int health = 15;

    // Cash
    [SerializeField] private CashUI cashUI;
    private int currentCash = 2;

    // Level
    [SerializeField] private LevelUI levelUI;
    private int maxPawnAmount = 1;
    private int currentPawnAmount = 0;
    private int level = 1;

    private int costToLevelUp = 4;


    private void Start()
    {
        cashUI.CashUIUpdate(currentCash);
        healthUI.SetHealthText(health);
        levelUI.SetLevelCostUI(costToLevelUp);
    }

    // Health
    public void SetPlayerHealth(int h)
    {
        health = h;
        healthUI.SetHealthText(health);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthUI.SetHealthText(health);
    }

    public int GetPlayerHealth()
    {
        return health;
    }

    // Cash
    public void GainCash(int amount)
    {
        currentCash += amount;
        cashUI.CashUIUpdate(currentCash);
    }
    
    public void SetCash(int amount)
    {
        currentCash = amount;
        cashUI.CashUIUpdate(currentCash);
    }
    public bool RemoveCash(int amount)
    {
        if (currentCash >= amount)
        {
            currentCash -= amount;
            cashUI.CashUIUpdate(currentCash);
            return true;
        }
        else
        {
            return false;
        }

    }

    public int GetCash()
    {
        return currentCash;
    }

    // Level
    public void ReduceCostToLevelUp(int num)
    {
        if(costToLevelUp > 0)
        {
            costToLevelUp -= num;
            levelUI.SetLevelCostUI(costToLevelUp);
        }
    }

    public void LevelUpButtonPress()
    {
        if(costToLevelUp <= currentCash)
        {
            RemoveCash(costToLevelUp);
            level++;
            ChangeMaxPawnAmount(level);

            costToLevelUp = 3 + ((level-1) * 2);
            levelUI.UIUpdate(level);
            levelUI.SetLevelCostUI(costToLevelUp);
        }
        else
        {
            HelperUI.Instance.ActivateHelperText("Not Enough Gold");
        }
    }

    public int GetPlayerLevel()
    {
        return level;
    }

    // Max Pawn
    public void ChangeMaxPawnAmount(int newMax)
    {
        maxPawnAmount = newMax;
    }

    public void ChangeCurrentPawnAmount(int newAmount)
    {
        currentPawnAmount = newAmount;
    }
    public bool IsPawnAmountFull()
    {
        GridUtil.Instance.UpdateMaxPawnsOnBoard();
        return currentPawnAmount >= maxPawnAmount;
    }
}
