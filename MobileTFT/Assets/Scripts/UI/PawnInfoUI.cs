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


    [SerializeField] private Image background;

    [SerializeField] private List<Image> types;

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
        rangeText.text = pStats.GetRange().ToString();


        foreach (Image type in types)
        {
            type.gameObject.SetActive(false);
        }

        for (int i = 0; i < pStats.GetComponent<Pawn>().GetPawnSO().types.Count; i++)
        {
            types[i].gameObject.SetActive(true);
            types[i].sprite = pStats.GetComponent<Pawn>().GetPawnSO().types[i].icon;
        }


        PawnSO SO = pStats.GetComponent<Pawn>().GetPawnSO();
        int pCost = 1;

        if (SO.starCount >= 2)
        {
            if (SO.prevStarPawnSO.starCount >= 2)
            {
                pCost = SO.prevStarPawnSO.prevStarPawnSO.cost;
            }
            else
            {
                pCost = SO.prevStarPawnSO.cost;
            }
        }
        else
        {
            pCost = SO.cost;
        }


        switch (pCost)
        {
            case 1:
                background.color = Color.grey;
                break;
            case 2:
                background.color = Color.green;
                break;
            case 3:
                background.color = Color.blue;
                break;
            case 4:
                background.color = Color.red;
                break;
            case 5:
                background.color = Color.yellow;
                break;


        }
    }
}
