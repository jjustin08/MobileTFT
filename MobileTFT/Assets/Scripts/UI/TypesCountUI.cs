using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypesCountUI : MonoBehaviour
{
    // probably should make this a script
    [SerializeField] private List<Image> typeIcons;
    [SerializeField] private List<TextMeshProUGUI> typeCount;
    [SerializeField] private List<TextMeshProUGUI> typeDescription;



    private void Start()
    {
        foreach (Image type in typeIcons)
        {
            type.gameObject.SetActive(false);
        }
    }

    public void UpdateUI()
    {
        
        List<Type> types = new List<Type>();
        List<int> tCount = new List<int>();


        List<GameObject> countedPawns = new List<GameObject>();

        foreach (Pawn p in GridUtil.Instance.GetAllPawns(true))
        {
            if (countedPawns.Contains(p.GetPawnSO().placedVisual))
            {
                continue;
            }
            countedPawns.Add(p.GetPawnSO().placedVisual);

            foreach (Type t in p.GetPawnSO().types)
            {
                if (!types.Contains(t))
                {
                    types.Add(t);
                    tCount.Add(1);
                }
                else
                {
                    int index = types.IndexOf(t);
                    tCount[index] += 1;
                }
            }
        }
        foreach (Image type in typeIcons)
        {
            type.gameObject.SetActive(false);
        }



        for (int i = 0; i < types.Count; i++) 
        {
            typeIcons[i].gameObject.SetActive(true);
            typeIcons[i].sprite = types[i].icon;
            typeDescription[i].text = types[i].description;
            this.typeCount[i].text = tCount[i].ToString();
        }

    }

}
