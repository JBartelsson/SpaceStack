using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    
    const string MOUSESENSITIVITY = "MouseSensitivity";
    
    void Start()
    {
        if (PlayerPrefs.HasKey(MOUSESENSITIVITY))
        {
            slider.value = PlayerPrefs.GetFloat(MOUSESENSITIVITY);
        } else
        {
            slider.value = 3f;
        }
    }

    public void SetMouseSensitivity()
    {
        PlayerPrefs.SetFloat(MOUSESENSITIVITY, slider.value);
        PlayerPrefs.Save();
    }
}
