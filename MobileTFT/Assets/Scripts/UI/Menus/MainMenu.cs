using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button singleplayerButton;
    [SerializeField] private Button multiplayerButton;
    [SerializeField] private Button tutorialButton;
    [SerializeField] private GameObject items;

    [SerializeField] private GameObject tutorialScreen;
    [SerializeField] private Button tutorialBackButton;

    private void Start()
    {
        singleplayerButton.onClick.AddListener(singleplayerButtonCLick);
        multiplayerButton.onClick.AddListener(multplayerplayerButtonCLick);
        tutorialButton.onClick.AddListener(TutorialButtonCLick);
        tutorialBackButton.onClick.AddListener(TutorialBackButtonCLick);
    }

    private void singleplayerButtonCLick()
    {
        SceneManager.LoadScene("SinglePlayer");
    }
    
    private void multplayerplayerButtonCLick()
    {
        SceneManager.LoadScene("Multiplayer");
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
