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
            pawnShop.ReRollPawns();
            CashManager.Instance.RemoveCash(1);
        });
    }

}
