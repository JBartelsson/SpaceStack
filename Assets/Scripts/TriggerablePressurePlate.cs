using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TriggerablePressurePlate : TriggerObject
{

    private Transform child;
    public TriggerObject trigger;
    public List<GameObject> collisionList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per framed
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other != null) { 
            if (other.CompareTag("Cube") || other.CompareTag("Player"))
            {
                GetComponent<MeshRenderer>().enabled = true;
                collisionList.Add(other.gameObject);
                if (!isActivated)
                {
                    Activate();
                }
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            if (collisionList.Contains(other.gameObject))
            {
                collisionList.Remove(other.gameObject);
            }
            if (collisionList.Count <= 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
                if (isActivated)
                {
                    Deactivate();
                }
            }
        }
    }

}
