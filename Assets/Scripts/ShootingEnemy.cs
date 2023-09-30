using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectileSpawn;
    [SerializeField] private float range;

    [SerializeField] private float shootingCooldown = 1f;
    [SerializeField] private float damage = 100;
    [SerializeField] private float MaxHealth;
    private float health;

    private bool _shotOnCooldown;

    private void Start()
    {
        Init();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    // Only shoot when Player was found and Shot is not on Cooldown
    //    if(other.CompareTag("Player"))
    //    {
    //        Debug.Log("Player entered Trigger!");
            
    //        if (!_shotOnCooldown)
    //        {
    //            Shoot();
    //        }
    //    }
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    // Only shoot when Player was found and Shot is not on Cooldown
    //    if(other.CompareTag("Player"))
    //    {
            
    //        if (!_shotOnCooldown)
    //        {
    //            Shoot();
    //        }
    //    }
    //}

    private void Shoot()
    {
        // Spawn Projectile
        GameObject projectileObject = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        projectileObject.GetComponent<AcidProjectile>().SetDamage(damage);
        _shotOnCooldown = true;
        
        StartCoroutine(StartCooldown());
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void Init()
    {
        gameObject.SetActive(true);
        health = MaxHealth;

    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, PlayerSingleton.Instance.transform.position) < range) {
            if (!_shotOnCooldown)
            {
                transform.forward = PlayerSingleton.Instance.transform.position - transform.position;
                Shoot();
            }
        }
    }

    // Resets _shotOnCooldown after shootingCooldown time has passed
    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(shootingCooldown);

        _shotOnCooldown = false;
    }
}
