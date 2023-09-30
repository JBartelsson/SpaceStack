using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuButtons : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    
    private int _nextLevelIndex;
    private void Start()
    {
        _nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

        if (_nextLevelIndex > 10)
        {
            nextLevelButton.interactable = false;
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(_nextLevelIndex);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
