using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private GameObject items;

    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private Button tutorialBackButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayButtonCLick);
        tutorialButton.onClick.AddListener(TutorialButtonCLick);
        tutorialBackButton.onClick.AddListener(TutorialBackButtonCLick);
    }

    private void PlayButtonCLick()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    
    private void TutorialButtonCLick()
    {
        items.SetActive(false);
        tutorialScreen.SetActive(true);
    }
    
    private void TutorialBackButtonCLick()
    {
        items.SetActive(true);
        tutorialScreen.SetActive(false);
    }
}
