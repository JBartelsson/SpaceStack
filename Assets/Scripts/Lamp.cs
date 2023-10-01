using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Lamp : MonoBehaviour
{
    [SerializeField] GameObject pointLight;
    [SerializeField] GameObject spotLight;
    [SerializeField] float flickerTimer;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = flickerTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = flickerTimer;
            pointLight.SetActive(!pointLight.activeSelf);
            spotLight.SetActive(!pointLight.activeSelf);
        }

    }
}
