using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText;

    public void SetHealthText(int h)
    {
        healthText.text = h.ToString();
    }
}
