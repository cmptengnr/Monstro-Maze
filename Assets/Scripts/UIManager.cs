using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Maze_TopDown");
    }
    public void ThirdPersonView()
    {
        SceneManager.LoadScene("Maze");
    }
    public void SettingsMenu()
    {
        SceneManager.LoadScene("Setting");
    }

    public void AboutMenu()
    {
        SceneManager.LoadScene("About");
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}


