using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 7.5f;
    [SerializeField] private float runningSpeed = 11.5f;
    [SerializeField] private float jumpSpeed = 8.0f;
    [SerializeField] private float gravity = 9.81f;

    [SerializeField] private Transform playerCamera;

    [SerializeField] private float sensivityX = 2.0f;
    [SerializeField] private float sensivityY = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;

    CharacterController characterController;

    Vector3 forward = Vector3.zero;
    Vector3 right = Vector3.zero;
    Vector3 moveDirection = Vector3.zero;

    float rotationX = 0;
    float curSpeedX = 0;
    float curSpeedY = 0;

    [HideInInspector] public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        forward = transform.TransformDirection(Vector3.forward);
        right = transform.TransformDirection(Vector3.right);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        forward = characterController.isGrounded ? transform.TransformDirection(Vector3.forward) : forward;
        right = characterController.isGrounded ? transform.TransformDirection(Vector3.right) : right;

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        curSpeedX = canMove ? (characterController.isGrounded ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : curSpeedX) : 0;
        curSpeedY = canMove ? (characterController.isGrounded ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : curSpeedY) : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * sensivityX;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * sensivityY, 0);
        }
    }
}
