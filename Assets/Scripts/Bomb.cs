using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float bombTimerMax;
    private float bombTimer;
    void Start()
    {
        bombTimer = bombTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        bombTimer -= Time.deltaTime;
        if (bombTimer < 0)
        {
            Detonate();
        }
    }

    public void Detonate()
    {
        Debug.Log("Boom");
        Destroy(gameObject);
    }
}
