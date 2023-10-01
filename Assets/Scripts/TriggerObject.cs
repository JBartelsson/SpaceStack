using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class TriggerObject : MonoBehaviour
{
    public bool isActivated = false;
    
    public event Action<bool> OnTrigger;

    public void Activate()
    {
        isActivated = true;
        OnTrigger?.Invoke(true);
    }

    public void Deactivate()
    {
        isActivated = false;
        OnTrigger?.Invoke(false);
    }
    
    public void Switch()
    { 
        isActivated = !isActivated;
        OnTrigger?.Invoke(isActivated);
    }
}
