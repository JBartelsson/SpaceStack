using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1f;
    private float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroySelf), 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += projectileSpeed * Time.deltaTime *  transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerSingleton.Instance.DamagePlayer(damage);
            Debug.Log("Player damaged");
        }
        
        Destroy(gameObject);
    }

    public void SetDamage(float damage)
    {
        Debug.Log($"set damage to" + damage);
        this.damage = damage;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
