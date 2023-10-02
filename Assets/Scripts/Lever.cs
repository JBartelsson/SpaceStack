using UnityEngine;

public class Lever : TriggerObject
{
    private bool _playerInRange;

    private Animator _animator;

    [SerializeField] AudioSource sound;
    
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
                sound.Play();
                _animator.SetBool("Active", isActivated);
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
