using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestExplosion : MonoBehaviour
{
    void OnTriggerEnter(Collider other) //Abfrage bei Start der Kollision (einmalig)
    {
        Debug.Log("Die Kollision beginnt.");
    }


    void OnTriggerStay(Collider other) //Abfrage bei jedem Frame der Kollision (oft)
    {
        Debug.Log("Eine Kollision findet statt.");
    }

    void OnTriggerExit(Collider other) // Abfrage am Endpunkt der Kollision
    {
        Debug.Log("Die Kollision endet.");
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        Debug.Log("Die Kollision ist da.");
    }
}