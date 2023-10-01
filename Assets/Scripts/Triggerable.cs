using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Triggerable : MonoBehaviour
{
    [SerializeField] protected TriggerObject trigger;

    public virtual void Trigger(bool active)
    {
        Debug.LogWarning("Trigger is not overridden!");
    }
}
