using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicSingleton : MonoBehaviour
{
    private MusicSingleton[] musics;

    // Start is called before the first frame update
    void Start()
    {
        musics = FindObjectsOfType<MusicSingleton>();
        
        if(musics.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
