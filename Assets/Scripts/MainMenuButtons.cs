using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    private AudioSource audioSource;
    
    private void Start()
    {
        if(!PlayerPrefs.HasKey("Volume")) PlayerPrefs.SetFloat("Volume", 1f);
        if(!PlayerPrefs.HasKey("MouseSensitivity")) PlayerPrefs.SetFloat("MouseSensitivity", 3f);
        
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");

        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        audioSource.Play();
        SceneManager.LoadScene("LevelSelectionNew");
    }

    public void OpenOptions()
    {
        audioSource.Play();
        SceneManager.LoadScene("Options");
    }

    public void OpenCredits()
    {
        audioSource.Play();
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        audioSource.Play();
        Application.Quit();
    }
    
    public void QuitOnClick()
    {
        audioSource.Play();
        Debug.Log("ButtonClick - Quit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
