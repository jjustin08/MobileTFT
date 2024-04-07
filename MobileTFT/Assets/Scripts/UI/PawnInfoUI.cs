using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PawnInfoUI : MonoBehaviour
{
    public static PawnInfoUI Instance;

    [SerializeField] private GameObject toggleGameObject;
    private bool isUIActive = false;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI atkSpdText;
    [SerializeField] private TextMeshProUGUI rangeText;

    private void Awake()
    {
        Instance = this;
        toggleGameObject.SetActive(isUIActive);
    }

    public void ToggleUI()
    {
        isUIActive = !isUIActive;
        toggleGameObject.SetActive(isUIActive);
    }


    public void UpdateUI(PawnStats pStats)
    {
        nameText.text = pStats.GetComponent<Pawn>().GetPawnSO().name;
        healthText.text = pStats.GetCurrentHealth().ToString();
        damageText.text = pStats.GetDamage().ToString();
        atkSpdText.text = pStats.GetAttackTime().ToString();
        rangeText.text = pStats.GetRange().ToString() ;
    }
}
