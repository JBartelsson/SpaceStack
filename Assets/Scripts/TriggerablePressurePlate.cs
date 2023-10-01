using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerablePressurePlate : TriggerObject
{

    private Transform child;
    public TriggerObject trigger;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != null) { 
            if (other.CompareTag("Cube") || other.CompareTag("Player"))
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }

}
