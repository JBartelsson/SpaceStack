using UnityEngine;

public class TriggerableDoor : Triggerable
{
    [SerializeField] private bool SlideDown;
    
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        trigger.OnTrigger += Trigger;
    }
    
    public override void Trigger(bool active)
    {
        _animator.SetBool(SlideDown ? "Down" : "Up", active);
    }
}
