using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{

    public GameObject OptionsCanvas;
    public bool isPaused;

    void Start()
    {
        OptionsCanvas.SetActive(false);
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resumed();
            }
            else
            {
                Paused();
            }

        }
    }




    public void Resumed()
    {
        OptionsCanvas.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;

    }

    public void Paused()
    {
        OptionsCanvas.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenubutton()
    {
        SceneManager.LoadScene("MainMenu");
    }





}
