using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReRollButtonUI : MonoBehaviour
{
    [SerializeField] private CardManager pawnShop;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            if(Player.Instance.GetPlayerStats().RemoveCash(1))
            {
                pawnShop.ReRollPawns();
            }
            else
            {
                HelperUI.Instance.ActivateHelperText("Not Enough Gold");
            }
        });
    }

}
