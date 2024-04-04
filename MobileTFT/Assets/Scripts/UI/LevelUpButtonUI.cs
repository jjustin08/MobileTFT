using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButtonUI : MonoBehaviour
{
    [SerializeField] private CardManager pawnShop;
    [SerializeField] private LevelManager levelManager;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            levelManager.GainExp(4);
        });
    }
}
