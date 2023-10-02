using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float bombTimerMax;
    [SerializeField] float bombRadius;
    [SerializeField] LayerMask destructionLayer;
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject visual;
    [SerializeField] float bombShakeAmplitude;
    [SerializeField] float bombShakeLength;
    [Header("Sound")]
    [SerializeField] AudioSource fuse;
    [SerializeField] AudioSource boomsound;


    private float bombTimer;
    private bool detonated = false;
    void Start()
    {
        bombTimer = bombTimerMax;
        fuse.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (detonated) return;
        bombTimer -= Time.deltaTime;
        if (bombTimer < 0)
        {
            Detonate();
            detonated = true;
        }
    }

    public void Detonate()
    {
        Debug.Log("Boom");

        PlayerSingleton.Instance.CameraShake(bombShakeAmplitude, bombShakeLength);
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
        boomsound.Play();
        particle.Play();
        Destroy(visual.gameObject);
        Invoke(nameof(DestroyAll) , 2f);
    }

    private void DestroyAll()
    {
        Destroy(gameObject);
    }
}
