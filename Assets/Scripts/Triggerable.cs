using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Triggerable : MonoBehaviour
{
    [SerializeField] private TriggerObject trigger;
    
    // Start is called before the first frame update
    void Start()
    {
        trigger.onTrigger += Trigger;
    }

    public abstract void Trigger(bool active);
}
