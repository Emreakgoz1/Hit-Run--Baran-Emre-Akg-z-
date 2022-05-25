using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
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
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
            yRotation += Input.GetAxis("Mouse X") * lookSensivity;
            xRotation -= Input.GetAxis("Mouse Y") * lookSensivity;
            xRotation = Mathf.Clamp(xRotation,-45,45);
            yRotation = Mathf.Clamp(yRotation,-45,45);
        
            currentXRotation = Mathf.SmoothDamp(currentXRotation,xRotation, ref xRotationV,lookSmoothnes);
            currentYRotation = Mathf.SmoothDamp(currentYRotation,yRotation, ref yRotationV,lookSmoothnes);
            transform.rotation = Quaternion.Euler(xRotation,yRotation,0);

    }
}
