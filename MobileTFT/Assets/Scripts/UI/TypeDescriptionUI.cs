using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeDescriptionUI : MonoBehaviour
{
    private TypeSO type;
    [SerializeField] TypeInfoUI typeInfoUI;

    private void Start()
    {
        //GetComponent<Button>().onClick.AddListener(() =>
        //{
        //    print("Hello");
        //    typeInfoUI.ToggleUI();
        //    typeInfoUI.UpdateUI(type);
        //});
    }

    public void SetType(TypeSO newType)
    {
        type  = newType;
    }
}
