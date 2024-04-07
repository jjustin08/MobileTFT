using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplayUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pawnChancesText;
    private bool toggle = false;
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            toggle = !toggle;
            pawnChancesText.gameObject.SetActive(toggle);
        });
    }

    private void UpdateUI()
    {
        Player.Instance.GetPlayerStats().GetPlayerLevel();
    }

}
