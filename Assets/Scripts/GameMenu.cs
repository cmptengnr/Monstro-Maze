using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.Audio;

public class GameMenu : MonoBehaviour
{
    int defaultSizeX = 1600;
    int defaultSizeY = 900;

    public AudioMixer audioMixer;

    public Text volumeText;

    public void SetVolume(float volume)
    {
        volumeText.Text = "Volume : " + audioMixer;
    }

    public void SetFullScreen(Boolean isFullScreen)
    {
        isFullScreen.fullScreen = isFullScreen;
    }
}