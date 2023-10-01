using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private GameObject winMenu;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winMenu.SetActive(true);
            StartCoroutine(StopGameSlowly());
        }
    }

    private IEnumerator StopGameSlowly()
    {
        while (Time.timeScale > 0.01f)
        {
            yield return null;
            Time.timeScale -= Time.fixedDeltaTime / 10 ;

            if (Time.timeScale < 0.1f)
            {
                Time.timeScale = 0;
            }
        }
        
    }
}
