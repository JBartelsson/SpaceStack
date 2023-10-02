using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionSliders : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        AudioListener.volume = volumeSlider.value;
    }
}
