using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScfipt : OptionsScript
{
    public GameObject SettingMenu;
    public bool isOppened;

    void Start()
    {
        SettingMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (isOppened)
            {
                DeactivateOptions();

            }
            else
            {
                ActivateOptions();

            }
        }
    }

    public void ActivateOptions()
    {
        SettingMenu.SetActive(true);
        isOppened = true;
        OptionsCanvas.SetActive(false);
    }

    public void DeactivateOptions()
    {
        SettingMenu.SetActive(false);
        isOppened = false;
        OptionsCanvas.SetActive(true);
    }


    public void GoBackButtonPressed()
    {
        DeactivateOptions();
    }

}
