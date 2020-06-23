using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionDropdown;



    Resolution[] resolutions;

    void start ()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        resolutionDropdown.AddOptions();
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void BackToMainMenu ()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}