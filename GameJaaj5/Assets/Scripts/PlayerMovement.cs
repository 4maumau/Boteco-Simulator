using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private InputAction wasd;
    [SerializeField] private float moveSpeed = 5;

    private Vector2 velocity;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        MovementInput();
    }

    private void MovementInput()
    {
        Vector2 moveInput = wasd.ReadValue<Vector2>();
        Vector2 moveVelocity = moveInput.normalized * moveSpeed;
        Move(moveVelocity);
    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }


    // new input system stuff
    private void OnEnable()
    {
        wasd.Enable();
    }

    private void OnDisable()
    {
        wasd.Disable();
    }
}

