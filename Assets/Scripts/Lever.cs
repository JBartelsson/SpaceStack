using UnityEngine;

public class Lever : TriggerObject
{
    private bool _playerInRange;

    private Animator _animator;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_playerInRange)
            {
                Switch();
                if (_isActivated)
                {
                    _animator.SetBool("Active", true);
                }
                else
                {
                    _animator.SetBool("Active", false);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }
}
