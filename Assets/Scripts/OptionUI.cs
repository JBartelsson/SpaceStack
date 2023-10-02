using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMouseSensitivity()
    {
        PlayerPrefs.SetFloat(MOUSESENSITIVITY, slider.value);
        PlayerPrefs.Save();
    }
}
