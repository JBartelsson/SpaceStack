using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectionButtons : MonoBehaviour
{
    [SerializeField] private AudioClip levelMusic;

    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void Back()
    {
        audioSource.Play();
        SceneManager.LoadScene("MainMenuNew");
    }

    public void LoadLevel(int levelIndex)
    {
        audioSource.Play();
        SceneManager.LoadScene("Level" + levelIndex);

        AudioSource audio = FindObjectOfType<MusicSingleton>().gameObject.GetComponent<AudioSource>();
        audio.clip = levelMusic;
        audio.Play();
    }
}
