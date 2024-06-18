using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PawnInfoUI : MonoBehaviour
{
    public static PawnInfoUI Instance;

    [SerializeField] private GameObject toggleGameObject;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI atkSpdText;
    [SerializeField] private TextMeshProUGUI rangeText;
    [SerializeField] private TextMeshProUGUI manaText;

    [SerializeField] private TextMeshProUGUI abilityDescriptionText;


    [SerializeField] private Image background;

    [SerializeField] private List<Image> types;

    private void Awake()
    {
        Instance = this;
        //toggleGameObject.SetActive(false);
    }


    public GameObject GetToggle()
    {
        return toggleGameObject;
    }

    public void ToggleUI()
    {
        toggleGameObject.SetActive(!toggleGameObject.activeSelf);
    }

    //public void UpdateUI(PawnSO pawnSO)
    //{
    //    nameText.text = pawnSO.name;

    //    healthText.text = pawnSO.health.ToString();
    //    damageText.text = pawnSO.damage.ToString();
    //    atkSpdText.text = pawnSO.attackTime.ToString();
    //    rangeText.text = pawnSO.range.ToString();
    //    manaText.text = pawnSO.mana.ToString();


    //    abilityDescriptionText.text = pawnSO.ability.description;


    //    foreach (Image type in types)
    //    {
    //        type.gameObject.SetActive(false);
    //    }
    //    for (int i = 0; i < pawnSO.types.Count; i++)
    //    {
    //        types[i].gameObject.SetActive(true);
    //        types[i].sprite = pawnSO.types[i].icon;
    //    }

        
    //    int pCost = pawnSO.cost;

    //    switch (pCost)
    //    {
    //        case 1:
    //            background.color = Color.grey;
    //            break;
    //        case 2:
    //            background.color = Color.green;
    //            break;
    //        case 3:
    //            background.color = Color.blue;
    //            break;
    //        case 4:
    //            background.color = Color.red;
    //            break;
    //        case 5:
    //            background.color = Color.yellow;
    //            break;


    //    }
    //}

    public void UpdateUI(PawnStats pStats)
    {
       // UpdateUI(pStats.GetComponent<Pawn>().GetPawnSO());

        healthText.text = pStats.GetCurrentHealth().ToString();
        damageText.text = pStats.GetDamage().ToString();
        atkSpdText.text = pStats.GetAttackTime().ToString();
        rangeText.text = pStats.GetRange().ToString();
        manaText.text = pStats.GetMana().ToString();
    }
}
