using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeInfoUI : MonoBehaviour
{
    [SerializeField] private GameObject toggleGameObject;

    [SerializeField] private Image background;

    [SerializeField] private TextMeshProUGUI typeNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    [SerializeField] private List<TextMeshProUGUI> amountTexts;
    [SerializeField] private List<TextMeshProUGUI> amountDescriptinsTexts;

    [SerializeField] private List<TextMeshProUGUI> otherPawns;

    private void Awake()
    {
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


    public void UpdateUI(TypeSO type)
    {
        typeNameText.text = type.typeName;
        descriptionText.text = type.description;


        for(int i = 0; i < amountTexts.Count; i++)
        {
            if (type.amounts.Count > i)
            {
                amountTexts[i].gameObject.SetActive(true);
                amountDescriptinsTexts[i].gameObject.SetActive(true);

                amountTexts[i].text = type.amounts[i].ToString() + ":";
                amountDescriptinsTexts[i].text = type.amountDescriptions[i];
            }
            else
            {
                amountTexts[i].gameObject.SetActive(false);
                amountDescriptinsTexts[i].gameObject.SetActive(false);
            }
        }

        for(int i = 0;i < otherPawns.Count;i++)
        {
            

            if (type.pawnsWithType.Count > i)
            {
                otherPawns[i].gameObject.SetActive(true);

                otherPawns[i].text = type.pawnsWithType[i].name;
            }
            else
            {
                otherPawns[i].gameObject.SetActive(false);
            }
            
        }
        

       
    }
}
