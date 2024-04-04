using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private HealthUI healthUI;
    private int level = 1;
    private int health = 15;

    [SerializeField] private int maxPawnAmount = 3;
    [SerializeField] private int currentPawnAmount = 0;

    private void Start()
    {
        healthUI.SetHealthText(health);
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
