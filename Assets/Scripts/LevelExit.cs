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
            Time.timeScale = 0f;
            StartCoroutine(ScaleTime(1f, 0f, .5f));
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

    IEnumerator ScaleTime(float start, float end, float time)     //not in Start or Update
    {
        float lastTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < time)
        {
            Time.timeScale = Mathf.Lerp(start, end, timer / time);
            timer += (Time.realtimeSinceStartup - lastTime);
            lastTime = Time.realtimeSinceStartup;
            yield return null;
        }

        Time.timeScale = end;
    }
}
