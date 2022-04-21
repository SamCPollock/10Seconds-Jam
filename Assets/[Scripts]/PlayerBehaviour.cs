using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    private Vector2 movementInput;
    public float moveSpeed;
    public float rotationSpeed;

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 movementVector3 = new Vector3(movementInput.x, 0, movementInput.y);
        transform.Translate(movementVector3 * moveSpeed * Time.deltaTime, Space.World);

        Vector3 movementDirection = movementInput;
        //movementDirection.Normalize();

        if (movementDirection != Vector3.zero)
        {
            //transform.forward = movementVector3;
            Quaternion toRotation = Quaternion.LookRotation(movementVector3, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }

    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
}