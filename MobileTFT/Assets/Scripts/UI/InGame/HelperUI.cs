using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelperUI : MonoBehaviour
{
    public static HelperUI Instance;
    [SerializeField] private TextMeshProUGUI helperText;

    private float maxFade = 2;
    private float currentFade = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(currentFade > 0)
        {
            currentFade -= Time.deltaTime;
            helperText.alpha = currentFade;
        }
    }

    public void ActivateHelperText(string text)
    {
        helperText.text = text;
        currentFade = maxFade;
    }
}
