using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Triggerable : MonoBehaviour
{
    [SerializeField] protected TriggerObject trigger;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public virtual void Trigger(bool active)
    {
        Debug.LogWarning("Trigger is not overriden!");
    }
}
