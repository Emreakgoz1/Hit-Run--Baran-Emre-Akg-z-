using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public int FPS = 120;
    public float speed =10f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;



    float xRotation;
    float yRotation;
    float lookSensivity =2f;
    float currentXRotation;
    float currentYRotation;
    float xRotationV;
    float yRotationV;
    float lookSmoothnes = 0.1f;


    CharacterController controller;



    
    void Start()
    {
        Application.targetFrameRate = FPS;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *=speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y =jumpSpeed;
            }
        }
            moveDirection.y -=gravity* Time.deltaTime;
            controller.Move(moveDirection*Time.deltaTime);


            yRotation += Input.GetAxis("Mouse X") * lookSensivity;
            xRotation -= Input.GetAxis("Mouse Y") * lookSensivity;
            xRotation = Mathf.Clamp(xRotation,-45,45);
            yRotation = Mathf.Clamp(yRotation,-45,45);
        
            currentXRotation = Mathf.SmoothDamp(currentXRotation,xRotation, ref xRotationV,lookSmoothnes);
            currentYRotation = Mathf.SmoothDamp(currentYRotation,yRotation, ref yRotationV,lookSmoothnes);
            transform.rotation = Quaternion.Euler(xRotation,yRotation,0);

    }
}
