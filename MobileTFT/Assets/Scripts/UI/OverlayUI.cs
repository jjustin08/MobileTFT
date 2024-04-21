using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayUI : MonoBehaviour
{
    [SerializeField] private Button cancelButton;
    [SerializeField] private PawnInfoUI pawnInfoUI;
    [SerializeField] private TypesCountUI typesCountUI;
    

    private GameObject activeUI;

    private bool isUIActive = false;

    private void Start()
    {
        cancelButton.onClick.AddListener(CancelButtonOnClick);
    }


    private void Update()
    {
        if (!isUIActive)
        {
            if (pawnInfoUI.GetToggle().activeSelf)
            {
                isUIActive = true;
                activeUI = pawnInfoUI.GetToggle();
            }


            if(isUIActive)
            {
                cancelButton.gameObject.SetActive(true);
            }
        }
        
    }

    private void CancelButtonOnClick()
    {
        activeUI.SetActive(false);
        activeUI = null;
        cancelButton.gameObject.SetActive(false);
        isUIActive = false;
    }
}
