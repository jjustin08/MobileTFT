using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class TypeFlipBook : MonoBehaviour
{
    //[SerializeField] private List<TypeSO> types;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;

    [SerializeField] private TypeInfoUI typeInfo;
    [SerializeField] private TextMeshProUGUI text;
    private int index = 0;

    //private void Awake()
    //{
    //    nextButton.onClick.AddListener(NextButtonClick);
    //    prevButton.onClick.AddListener(PrevButtonClick);
    //    //typeInfo.UpdateUI(types[0]);
    //    //text.text = index+1 + "/" + types.Count;
    //}

    //private void NextButtonClick()
    //{
    //    if (index < types.Count - 1)
    //    {
    //        index++;
    //        typeInfo.UpdateUI(types[index]);
    //        text.text = index + 1 + "/" + types.Count;

    //    }
    //}
    //private void PrevButtonClick()
    //{
    //    if (index > 0)
    //    {
    //        index--;
    //        typeInfo.UpdateUI(types[index]);
    //        text.text = index + 1 + "/" + types.Count;
    //    }
    //}
}
