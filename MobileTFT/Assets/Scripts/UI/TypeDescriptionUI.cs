using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypeDescriptionUI : MonoBehaviour
{
    [SerializeField] private GameObject descriptionText;
    private bool toggle;

    private void Awake()
    {
        descriptionText.SetActive(false);
        GetComponent<Button>().onClick.AddListener(() =>
        {
            toggle = !toggle;
            descriptionText.SetActive(toggle);
        });
    }
}
