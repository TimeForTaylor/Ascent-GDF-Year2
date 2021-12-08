using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //void start()
    //{
    //    Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreen);;
    //}

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    
    public void Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
