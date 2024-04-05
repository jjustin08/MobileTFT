using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pawnName;
    [SerializeField] private TextMeshProUGUI cost; // will change this to not text
    [SerializeField] private Image art;
    [SerializeField] private Image background;


    [SerializeField] private List<Image> types;



    public void UpdateVisual(PawnSO SO)
    {
        pawnName.text = SO.name;

        string co = "";
        for(int i = 0; i < SO.cost; i++)
        {
            co += "*";
        }
        cost.text = co;

        for(int i = 0;i < SO.types.Count;i++)
        {
            types[i].gameObject.SetActive(true);
            types[i].sprite = SO.types[i].icon;
        }

    }
}
