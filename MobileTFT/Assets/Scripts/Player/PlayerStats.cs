using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int level = 1;

    [SerializeField] private int maxPawnAmount = 3;
    [SerializeField] private int currentPawnAmount = 0;


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
}
