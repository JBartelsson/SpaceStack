using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class MenuInit : MonoBehaviour
{
    public AudioClip menuMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        MusicSingleton[] audios = FindObjectsOfType<MusicSingleton>();

        for (int i = 0; i < audios.Length; i++)
        {
            audios[i].GetComponent<AudioSource>().clip = menuMusic;
            audios[i].GetComponent<AudioSource>().Play();
        }
    }
}
