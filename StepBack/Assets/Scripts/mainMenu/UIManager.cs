using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject howToPlayPanel;
    public GameObject creatorsPanel;

    void Start()
    {
        mainMenuPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        creatorsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Sahne1");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        creatorsPanel.SetActive(false);
    }

    public void ShowCreators()
    {
        creatorsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
    }

    public void CloseSubPanels()
    {
        howToPlayPanel.SetActive(false);
        creatorsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        howToPlayPanel.SetActive(false);
        creatorsPanel.SetActive(false);
    }


}
