using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenuu;
    public GameObject settings;
    public bool settingsLoaded;

    void Start()
    {
        settings.SetActive(false);
    }

  
    void Update()
    {
        if (settingsLoaded)
        {
            SettingsOpen();
        }
        else
        {
            SettingsClose();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsOpen()
    {
        settings.SetActive(true);
        settingsLoaded = true;
        MainMenuu.SetActive(false);

    }

    public void SettingsClose()
    {
        settings.SetActive(false);
        settingsLoaded = false;
        MainMenuu.SetActive(true);
    }

    public void BackButton()
    {
        SettingsClose();
    }

}
