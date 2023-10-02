using UnityEngine;

public class TriggerableDoor : Triggerable
{
    [SerializeField] private bool SlideDown;
    [SerializeField] private AudioSource slidingDoor;
    
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        trigger.OnTrigger += Trigger;
    }
    
    public override void Trigger(bool active)
    {
        slidingDoor.Play();
        _animator.SetBool(SlideDown ? "Down" : "Up", active);
    }
}
