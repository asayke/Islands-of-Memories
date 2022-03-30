using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;

    [Header("Movement")]
    public float speed = 2f;
    public float gravity = -9.18f;
    public float jumpHeight = 1.5f;
    
    [Header("Camera & Character Syncing")]
    public float lookDIstance = 5;
    public float lookSpeed = 5;
    public Transform camCenter;


    [Header("GroundCheck")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    void Start()
    {

    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);  // For Check Player is Grounded Or Not

        float x = Input.GetAxis("Horizontal");        //To Get Input from A and D Keys
        float z = Input.GetAxis("Vertical");         // To Get Input from W and S Keys
        // ———- Player Movement Start ——————————–
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        // —————- Player Movement End—————————–
        // ———- Code for Running ———-
        if (Input.GetKey(KeyCode.LeftShift) && z > 0)
        {
            speed = 5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 2f;
        }
        // ————— Running End ———————
        // ———-----------Jump-------- ———————
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        // ——————————– Jump Ends ——————————–
        
        
        //———– Player Rotation with Camera ————————————-
        RotateToCamView();
        //——————————————————————————–
    }

    //———————- Rotate with Camera Start ————————————
    void RotateToCamView()
    {
        Vector3 camCenterPos = camCenter.position;
        Vector3 lookPoint = camCenterPos + (camCenter.forward * lookDIstance);
        Vector3 direction = lookPoint - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation.x = 0;
        lookRotation.z = 0;
        Quaternion finalRotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
        transform.rotation = finalRotation;
    }
    //———————– Rotate With Camera End ————————————–
}