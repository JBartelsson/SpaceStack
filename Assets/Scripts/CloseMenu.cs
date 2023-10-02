using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseMenu : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void BackToMainMenu()
    {
        audioSource.Play();
        SceneManager.LoadScene("MainMenuNew");
    }
}
