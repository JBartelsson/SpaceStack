using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool _gamePaused;

    [SerializeField] private GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenuNew");
    }

    public void Continue()
    {
        _gamePaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
