using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ButtonScript : MonoBehaviour
{

    public Slider VolumeSlider;
    public AudioMixer VolumeMixer;
    public float Value;

    public void Start()
    {
        VolumeMixer.GetFloat("Volume", out Value);
        VolumeSlider.value = Value;
    }

    public void SetVolume()
    {
        VolumeMixer.SetFloat("Volume", VolumeSlider.value);
    }

    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
