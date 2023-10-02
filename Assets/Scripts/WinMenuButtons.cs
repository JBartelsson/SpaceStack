using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinMenuButtons : MonoBehaviour
{
    private AudioSource audioSource;
    
    [SerializeField] private Button nextLevelButton;
    
    private int _nextLevelIndex;
    
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        _nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        
        Debug.Log(SceneManager.sceneCountInBuildSettings);
        
        if (_nextLevelIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            nextLevelButton.interactable = false;
        }
    }

    public void LoadNextLevel()
    {
        audioSource.Play();
        SceneManager.LoadScene(_nextLevelIndex);
    }

    public void Restart()
    {
        audioSource.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        audioSource.Play();
        SceneManager.LoadScene("MainMenuNew");
    }
}
