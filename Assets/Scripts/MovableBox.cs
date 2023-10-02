using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBox : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private LayerMask acidLayer;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
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
    }
}
