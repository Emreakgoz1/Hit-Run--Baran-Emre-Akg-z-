using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject Bullet_Emitter;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Grenade;

    [SerializeField] float Grenade_Forward_Force;
    [SerializeField] float Bullet_Forward_Force;
 
    private void Start()
    {
       
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) ,out hit,Mathf.Infinity) && hit.transform.tag == "Destroyable")
        {   
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*hit.distance,Color.red);
       
            ÝnstantiateBullets(hit,1);
            ÝnstantiateGrenades(hit, 1);
            
        }
       
    }
    public void ÝnstantiateBullets(RaycastHit hit,int destroy)
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
            Temporary_Bullet_Handler.transform.Rotate(90, 0, 0);
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
            Destroy(Temporary_Bullet_Handler, 5.0f);
           
            if (destroy==1)
            {
                Temporary_RigidBody = hit.transform.gameObject.GetComponent<Rigidbody>();
                Temporary_RigidBody.AddForce(0, 2, 0,ForceMode.Force);
                Destroy(hit.transform.gameObject,0.5f);
            }
        }
    }
    public void ÝnstantiateGrenades(RaycastHit hit, int destroy)
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Grenade, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
            Temporary_Bullet_Handler.transform.Rotate(90, 0, 0);
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            Temporary_RigidBody.AddForce(transform.forward * Grenade_Forward_Force);
            Destroy(Temporary_Bullet_Handler, 5.0f);

            if (destroy == 1)
            {
                Temporary_RigidBody = hit.transform.gameObject.GetComponent<Rigidbody>();
                Temporary_RigidBody.AddExplosionForce(1000,transform.position,5);
                Destroy(hit.transform.gameObject, 0.5f);
            }


        }
    }

}