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

        int pCost = 1;

        if(SO.starCount >= 2)
        {
            if(SO.prevStarPawnSO.starCount >= 2)
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
