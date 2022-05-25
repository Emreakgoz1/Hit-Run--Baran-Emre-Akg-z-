using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject Bullet_Emitter;
    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject Grenade;

    [SerializeField] float Grenade_Forward_Force;
    [SerializeField] float Bullet_Forward_Force;
    public Spawner sPawner;
    int counter = 0;

 
    private void Start()
    {
       
    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) ,out hit,Mathf.Infinity) && hit.transform.tag=="Destroyable")
        {   
            Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward)*hit.distance,Color.red);
       
            ÝnstantiateBullets(hit,1);
            ÝnstantiateGrenades(hit, 1);
            

        }
        if (sPawner.numberOfRows*sPawner.objectsPerRows==sPawner.whitecubeCounter+counter)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            FindObjectOfType<FirstPersonController>().enabled=false;
            this.enabled = false;
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
            counter++;

            if (destroy==1)
            {
                Temporary_RigidBody = hit.transform.gameObject.GetComponent<Rigidbody>();
                Temporary_RigidBody.AddForce(0, 2, 0,ForceMode.Force);
                Destroy(hit.transform.gameObject,0.5f);
                foreach (Transform coloredCube in sPawner.Cubes)
                {
                    if (coloredCube.transform.tag=="Destroyable")
                    {
                       coloredCube.GetComponent<Renderer>().material.color = sPawner.WallColors[Random.Range(1, sPawner.WallColors.Count)];
                    }
                }
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
            counter++;

            if (destroy == 1)
            {
                Temporary_RigidBody = hit.transform.gameObject.GetComponent<Rigidbody>();
                Temporary_RigidBody.AddExplosionForce(1000,transform.position,5);
                Destroy(hit.transform.gameObject, 0.5f);
            }


        }
    }

}