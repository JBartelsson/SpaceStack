using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerSingleton.Ability powerUpType;
    [Header("Visuals")]
    [SerializeField] private GameObject minimizeVisual;
    [SerializeField] private GameObject dashVisual;
    [SerializeField] private GameObject bombVisual;
    [SerializeField] private GameObject shootVisual;

    public float roatioSpeed = 1.0f;

    private void Awake()
    {
        dashVisual.SetActive(false);
        shootVisual.SetActive(false);
        bombVisual.SetActive(false);
        minimizeVisual.SetActive(false);

        switch (powerUpType)
        {
            case PlayerSingleton.Ability.None:
                break;
            case PlayerSingleton.Ability.Dash:
                dashVisual.SetActive(true);
                break;
            case PlayerSingleton.Ability.Shoot:
                shootVisual.SetActive(true);

                break;
            case PlayerSingleton.Ability.Grante:
                bombVisual.SetActive(true);

                break;
            case PlayerSingleton.Ability.Minimize:
                minimizeVisual.SetActive(true);
                break;
        }
    }

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSingleton.Instance.pushAbilityStack(powerUpType);
            Destroy(gameObject);
        }
        
    }

}
