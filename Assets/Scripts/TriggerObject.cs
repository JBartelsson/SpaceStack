using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class TriggerObject : MonoBehaviour
{
    public bool _isActivated;

    public event Action<bool> onTrigger;

    public void Activate()
    {
        _isActivated = true;
        onTrigger.Invoke(true);
    }

    public void Deactivate()
    {
        _isActivated = false;
        onTrigger.Invoke(false);
    }
    
    public void Switch()
    {
        if (_isActivated)
        {
            _isActivated = false;
            onTrigger.Invoke(false);
        }
        else
        {
            _isActivated = true;
            onTrigger.Invoke(true);
        }
    }
}
