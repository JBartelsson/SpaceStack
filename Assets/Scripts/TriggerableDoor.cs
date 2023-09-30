using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TriggerableDoor : Triggerable
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        trigger.OnTrigger += Trigger;
    }
    
    public override void Trigger(bool active)
    {
        base.Trigger(active);
        _animator.SetBool("Open", active);
    }
}
