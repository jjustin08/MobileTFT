using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class FlipBook : MonoBehaviour
{
    [SerializeField] private List<GameObject> images;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;

    [SerializeField] private TextMeshProUGUI text;
    private int index = 0;

    private void Awake()
    {
        nextButton.onClick.AddListener(NextButtonClick);
        prevButton.onClick.AddListener(PrevButtonClick);
        text.text = index + 1 + "/" + images.Count;
    }

    private void NextButtonClick()
    {
        if(index < images.Count -1 ) 
        {
            images[index].SetActive(false);
            index++;
            images[index].SetActive(true);
            text.text = index+1 + "/" + images.Count;
        }
    }
    private void PrevButtonClick()
    {
        if (index > 0)
        {
            images[index].SetActive(false);
            index--;
            images[index].SetActive(true);
            text.text = index + 1 + "/" + images.Count ;
        }
    }
}
