using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlipBook : MonoBehaviour
{
    [SerializeField] private List<GameObject> images;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;

    private int index = 0;

    private void Awake()
    {
        nextButton.onClick.AddListener(NextButtonClick);
        prevButton.onClick.AddListener(PrevButtonClick);
    }

    private void NextButtonClick()
    {
        if(index < images.Count -1 ) 
        {
            images[index].SetActive(false);
            index++;
            images[index].SetActive(true);
        }
    }
    private void PrevButtonClick()
    {
        if (index > 0)
        {
            images[index].SetActive(false);
            index--;
            images[index].SetActive(true);
        }
    }
}
