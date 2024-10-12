using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;

    Rigidbody rb;
    CapsuleCollider collider; // Reference to the capsule collider

    private bool isCrouching = false; // Track crouch state
    public float crouchHeight = 0.5f; // Height when crouching
    public float standHeight = 2.0f; // Normal height

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        collider = GetComponent<CapsuleCollider>();
        collider.height = standHeight; // Set initial height
    }

    private void Update()
    {
        MyInput();
        HandleCrouch();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Adjust speed when crouching
        float currentSpeed = isCrouching ? moveSpeed * 0.5f : moveSpeed;

        rb.AddForce(moveDirection.normalized * currentSpeed * 10f, ForceMode.Force);
    }

    private void HandleCrouch()
    {
        // Hold Shift to crouch
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isCrouching = true;
            collider.height = crouchHeight; // Change collider height
        }
        else
        {
            isCrouching = false;
            collider.height = standHeight; // Reset collider height
        }
    }

    public bool IsCrouching()
    {
        return isCrouching; // Method to check if the player is crouching
    }
}
