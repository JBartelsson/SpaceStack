using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float bombTimerMax;
    [SerializeField] float bombRadius;
    [SerializeField] LayerMask destructionLayer;

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
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRadius, destructionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent<Stone>(out Stone stone))
            {
                stone.Explode();
            }
            if (colliders[i].TryGetComponent<PlayerSingleton>(out PlayerSingleton player))
            {
                float damage = 100;
                player.DamagePlayer(damage);
            }
        }
        Destroy(gameObject);
    }
}
