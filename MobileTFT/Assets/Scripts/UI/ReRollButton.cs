using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReRollButton : MonoBehaviour
{
    [SerializeField] private CardManager pawnShop;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            pawnShop.ReRollPawns();

        });
    }

}
