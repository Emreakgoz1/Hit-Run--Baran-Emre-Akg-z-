using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
        [SerializeField] GameObject Bullet_Emitter;
        [SerializeField] GameObject Bullet;
        [SerializeField] float Bullet_Forward_Force;
      
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject Temporary_Bullet_Handler;
                Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                Temporary_Bullet_Handler.transform.Rotate(90,0,0);
                Rigidbody Temporary_RigidBody;
                Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
                Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
                Destroy(Temporary_Bullet_Handler, 5.0f);
            }
        }
    
}
