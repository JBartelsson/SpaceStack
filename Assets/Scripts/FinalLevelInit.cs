using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FinalLevelInit : MonoBehaviour
{
    public AudioClip levelMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < 5; i++)
        {
            giveRandomPowerUp();
        }
        InvokeRepeating(nameof(giveRandomPowerUp), 3f, 3f);
        
        
        AudioSource audio = FindObjectOfType<MusicSingleton>().gameObject.GetComponent<AudioSource>();
        audio.clip = levelMusic;
        audio.Play();
    }

    void giveRandomPowerUp()
    {
        int rng = Mathf.FloorToInt(Random.Range(0, 4));
        Debug.Log(rng);
        if (PlayerSingleton.Instance.getAbilityStack().Count > 7) return;
        switch (rng)
        {
            case 0:
                Debug.Log("bla");
                PlayerSingleton.Instance.pushAbilityStack(PlayerSingleton.Ability.Dash);
                break;
            case 1:
                PlayerSingleton.Instance.pushAbilityStack(PlayerSingleton.Ability.Grante);
                break;
            case 2:
                PlayerSingleton.Instance.pushAbilityStack(PlayerSingleton.Ability.Minimize);
                break;
            case 3:
                //PlayerSingleton.Instance.pushAbilityStack(PlayerSingleton.Ability.));
                break;
            default:
                break;
        };


    }
    // Update is called once per frame
    void Update()
    {


    }
}
