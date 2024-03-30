using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int maxPawnAmount = 3;
    [SerializeField] private int currentPawnAmount = 0;


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
}
