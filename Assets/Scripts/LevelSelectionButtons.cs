using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionButtons : MonoBehaviour
{
    [SerializeField] private AudioClip levelMusic;
    
    public void Back()
    {
        SceneManager.LoadScene("MainMenuNew");
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene("Level" + levelIndex);

        AudioSource audio = FindObjectOfType<AudioSource>();
        audio.clip = levelMusic;
        audio.Play();
    }
}
