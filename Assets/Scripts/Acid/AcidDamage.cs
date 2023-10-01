using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the game object involved in the collision has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the PlayerSingleton component from the player game object
            PlayerSingleton playerSingleton = collision.gameObject.GetComponent<PlayerSingleton>();

            Debug.Log("Collision erfolgt");
            if (playerSingleton != null)
            {
                // Call the DamagePlayer method on the PlayerSingleton script
                playerSingleton.DamagePlayer(100);
            }
        }
    }
}
