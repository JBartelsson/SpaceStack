using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charakterbewegung : MonoBehaviour
{
public float speed;
private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //_characterController.SimpleMove(Vector3.forward * speed);
        _characterController.Move(Movement() * Time.deltaTime);
    }

    Vector3 Movement()
    {
        Vector3 moveVector = Vector3.zero;

        moveVector += transform.forward * Input.GetAxis("Vertical");
        moveVector += transform.right * Input.GetAxis("Horizontal");

        moveVector *= speed;

        return moveVector;
    }

}
