using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    private void Start()
    {
        if(!PlayerPrefs.HasKey("Volume")) PlayerPrefs.SetFloat("Volume", 1f);
        if(!PlayerPrefs.HasKey("MouseSensitivity")) PlayerPrefs.SetFloat("MouseSensitivity", 3f);
        
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
    }

    public void Play()
    {
        SceneManager.LoadScene("LevelSelectionNew");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void QuitOnClick()
    {
        Debug.Log("ButtonClick - Quit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
