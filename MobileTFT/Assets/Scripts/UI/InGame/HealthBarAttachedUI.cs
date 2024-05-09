using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarAttachedUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killCountText;
    [SerializeField] private Image starImage1;
    [SerializeField] private Image starImage2;
    [SerializeField] private Image starImage3;

    [SerializeField] private Image abilityBar;



    public void UpdateManaBar(float max, float current)
    {
        abilityBar.fillAmount = current / max;
    }

    public void SetKillCountText(int count)
    {
        killCountText.text = count.ToString();
    }


    public void SetStarImage(int num)
    {
        if(num == 3)
        {
            starImage3.gameObject.SetActive(true);
            starImage2.gameObject.SetActive(false);
            starImage1.gameObject.SetActive(false);
        }
        else if( num ==2)
        {
            starImage3.gameObject.SetActive(false);
            starImage2.gameObject.SetActive(true);
            starImage1.gameObject.SetActive(false);

        }
        else if( num ==1) 
        {
            starImage3.gameObject.SetActive(false);
            starImage2.gameObject.SetActive(false);
            starImage1.gameObject.SetActive(true);
        }
    }
}
