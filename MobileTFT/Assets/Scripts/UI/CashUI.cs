using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cashText;

    public void CashUIUpdate(int currentCash)
    {
        cashText.text = currentCash.ToString();
    }
}
