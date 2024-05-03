using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpButtonUI : MonoBehaviour
{
    [SerializeField] private CardManager pawnShop;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            Player.Instance.GetPlayerStats().LevelUpButtonPress();
        });
    }
}
