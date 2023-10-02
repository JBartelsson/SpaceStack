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
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        for (int i = 0; i < audios.Length; i++)
        {
            audios[i].clip = menuMusic;
            audios[i].Play();
        }
    }
}
