using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerSingleton playerSingleton = collision.gameObject.GetComponent<PlayerSingleton>();

            if (playerSingleton != null)
            {
                playerSingleton.DamagePlayer(100);
            }
        }
    }
}
