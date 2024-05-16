using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PawnFlipBook : MonoBehaviour
{
    //[SerializeField] private List<PawnSO> pawns;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;

    [SerializeField] private PawnInfoUI pawnInfo;

    [SerializeField] private TextMeshProUGUI text;

    private int index = 0;

    //private void Awake()
    //{
    //    nextButton.onClick.AddListener(NextButtonClick);
    //    prevButton.onClick.AddListener(PrevButtonClick);
    //    pawnInfo.UpdateUI(pawns[0]);
    //    text.text = index + 1 + "/" + pawns.Count ;
    //}

    //private void NextButtonClick()
    //{
    //    if (index < pawns.Count - 1)
    //    {
    //        index++;
    //        pawnInfo.UpdateUI(pawns[index]);
    //        text.text = index + 1 + "/" + pawns.Count;

    //    }
    //}
    //private void PrevButtonClick()  
    //{
    //    if (index > 0)
    //    {
    //        index--;
    //        pawnInfo.UpdateUI(pawns[index]);
    //        text.text = index + 1 + "/" + pawns.Count;
    //    }
    //}
}
