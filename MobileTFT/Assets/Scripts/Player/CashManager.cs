using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public static CashManager Instance;
    [SerializeField] private TextMeshProUGUI cashText;

    private int currentCash = 10;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CashUIUpdate();
    }

    private void CashUIUpdate()
    {
        cashText.text = currentCash.ToString();
    }

    public void GainCash(int amount)
    {
        currentCash += amount;
        CashUIUpdate();
    }
    public bool RemoveCash(int amount)
    {
        if(currentCash >= amount)
        {
            currentCash -= amount;
            CashUIUpdate();
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
}
