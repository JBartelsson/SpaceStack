using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBox : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private LayerMask acidLayer;
    [SerializeField] private AudioSource sound;
    Vector3 oldPos;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        oldPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerSingleton>(out PlayerSingleton player))
        {
            if (player.isMini)
            {
                _rb.isKinematic = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _rb.isKinematic = false;
        }
    }

    private void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10f, acidLayer))
        {
            if (hit.collider.CompareTag("Acid")){
                _rb.constraints = RigidbodyConstraints.None;
            }
        }
        if (oldPos != transform.position)
        {
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        } else
        {
            sound.Stop();

        }
        oldPos = transform.position;

    }
}
