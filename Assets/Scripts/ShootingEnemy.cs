using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject projectileSpawn;

    [SerializeField] private float shootingCooldown = 1f;

    private bool _shotOnCooldown;

    private void OnTriggerEnter(Collider other)
    {
        // Only shoot when Player was found and Shot is not on Cooldown
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player entered Trigger!");
            
            if (!_shotOnCooldown)
            {
                Shoot();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Only shoot when Player was found and Shot is not on Cooldown
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player stays in Trigger!");
            
            if (!_shotOnCooldown)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        // Spawn Projectile
        Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        
        _shotOnCooldown = true;
        
        StartCoroutine(StartCooldown());
    }

    // Resets _shotOnCooldown after shootingCooldown time has passed
    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(shootingCooldown);

        _shotOnCooldown = false;
    }
}
