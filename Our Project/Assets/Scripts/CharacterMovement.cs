using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float lookSensitivity = 5f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float gravity = 9.81f;

    private Vector2 moveVector;
    private Vector2 lookVector;

    private Vector3 rotation;

    private float verticalVelocity;

    private CharacterController characterController;
    private Animator animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    public void OnMove(InputAction.CallbackContext context) // With this we read input from CallbackContext
    {
        moveVector = context.ReadValue<Vector2>(); //form input to 2d vector
    }

    private void Move()
    {
        verticalVelocity += -gravity * Time.deltaTime;

        if (characterController.isGrounded && verticalVelocity < 0) 
        {
            verticalVelocity += -0.1f * gravity * Time.deltaTime;
        }


        Vector3 move = (transform.right * moveVector.x) + (transform.forward * moveVector.y) + (transform.up * verticalVelocity);

        // moveVector.x  = horizontal input, moveVector.y = vertical input


        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookVector = context.ReadValue<Vector2>();
    }

    private void Rotate()
    {
        rotation.y += lookVector.x * lookSensitivity * Time.deltaTime;
        transform.localEulerAngles = rotation;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(characterController.isGrounded && context.performed)
        {
            animator.Play("Jump");
            Jump();
        }
    }

    private void Jump()
    {
        verticalVelocity = Mathf.Sqrt(jumpHeight * gravity);
    }
}
