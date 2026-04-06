using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform cameraTransform;

    private InputSystem_Actions inputActions;
    public event Action<Vector2> OnMove;


    private CharacterController characterController;
    private Vector2 inputMovement;
    private Vector3 moveDirection;

    private void OnEnable()
    {
        inputActions = new InputSystem_Actions();
        inputActions.Enable();
        inputActions.Player.Move.performed += InputMove;
        inputActions.Player.Move.canceled += InputMove;

    }

    void OnDisable()
    {
        inputActions.Disable();
        inputActions.Player.Move.performed -= InputMove;
        inputActions.Player.Move.canceled -= InputMove;
    }

    private void InputMove(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        moveDirection = cameraTransform.forward * inputMovement.y + cameraTransform.right * inputMovement.x;
        moveDirection.y = 0;
        characterController.Move(moveDirection * speed * Time.deltaTime);
    }
}
