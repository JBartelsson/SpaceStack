using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
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
        Debug.Log(other.transform);
        if (other.TryGetComponent<ShootingEnemy>(out ShootingEnemy enemy))
        {
            enemy.Damage(damage);
        }
        if (!other.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
        
    }

    public void SetDamage(float damage)
    {
        Debug.Log($"set damage to" + damage);
        this.damage = damage;
    }

    public void SetSpeed(float speed)
    {
        projectileSpeed = speed;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
