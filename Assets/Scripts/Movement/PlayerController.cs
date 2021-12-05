using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _playerCamera = null;
    [SerializeField] private float _mouseSensitivity = 3.5f;
    [SerializeField] private float _walkSpeed = 6.0f;
    [SerializeField] private float _jump = 10f;
    [SerializeField] private float _gravity = -13.0f;
    [SerializeField] [Range(0.0f, 0.5f)] private float _moveSmoothTime = 0.3f;
    [SerializeField] [Range(0.0f, 0.5f)] private float _mouseSmoothTime = 0.03f;

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;
    CharacterController controller;
    private float _oldWalkSpeed;

    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _oldWalkSpeed = _walkSpeed;
    }

    private void Update()
    {
        if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            _walkSpeed = _oldWalkSpeed + 3f;
        else _walkSpeed = _oldWalkSpeed;
        UpdateMouseLook();
        UpdateMovement();
    }

    private void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));


        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity,
            _mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * _mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        _playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        transform.Rotate(Vector3.up * currentMouseDelta.x * _mouseSensitivity);
    }

    private void UpdateMovement()
    {
        if (Input.GetKey(KeyCode.LeftControl))
            controller.height = 0.6f;
        if (Input.GetKeyUp(KeyCode.LeftControl))
            controller.height = 1.8f;
        
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, _moveSmoothTime);

        if (controller.isGrounded)
        {
            velocityY = 0f;
            if (Input.GetKey(KeyCode.Space))
                velocityY += _jump;
        }

        velocityY += _gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * _walkSpeed +
                           Vector3.up * velocityY;


        controller.Move(velocity * Time.deltaTime);
    }
}