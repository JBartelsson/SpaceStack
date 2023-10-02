using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private AudioSource audioSource;
    
    private bool _gamePaused;

    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            audioSource.Play();
            
            if (_gamePaused)
            {
                _gamePaused = false;
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            else
            {
                _gamePaused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }
    }

    public void Retry()
    {
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        audioSource.Play();
        SceneManager.LoadScene("MainMenuNew");
    }

    public void Continue()
    {
        audioSource.Play();
        _gamePaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
