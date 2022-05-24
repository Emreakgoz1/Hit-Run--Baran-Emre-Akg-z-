using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float MouseSensivity = 100f;
    public Transform Rifle;
    float xRotation = 0f; 
    

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*MouseSensivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*MouseSensivity*Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(-90, xRotation, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        Rifle.Rotate(Vector3.up * mouseX);
       

        
    }
}
