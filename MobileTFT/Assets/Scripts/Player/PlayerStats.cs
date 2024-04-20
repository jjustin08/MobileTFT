using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    [SerializeField] private HealthUI healthUI;
    [SerializeField] private CashUI cashUI;
    [SerializeField] private LevelUI levelUI;

    [SerializeField] private int maxPawnAmount = 3;
    [SerializeField] private int currentPawnAmount = 0;



    private int level = 1;
    private int health = 15;
    private int currentCash = 10;

    

    private void Start()
    {
        cashUI.CashUIUpdate(currentCash);
        healthUI.SetHealthText(health);
    }



    public void GainCash(int amount)
    {
        currentCash += amount;
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
    public void AddPawnAmount()
    {
        currentPawnAmount += maxPawnAmount;
    }

    public void RemovePawnAmount() 
    { 
        currentPawnAmount -= maxPawnAmount;
    }

    public void SetPlayerLevel(int lvl)
    {
        level = lvl;


        //move this somewhere else
        ChangeMaxPawnAmount(lvl);
    }

    public int GetPlayerLevel() 
    { 
        return level;
    }

    public int GetPlayerHealth()
    {
        return health;
    }
}
