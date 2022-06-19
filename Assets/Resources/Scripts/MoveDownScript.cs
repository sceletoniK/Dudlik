using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveDownScript : MonoBehaviour
{
    static private Rigidbody dudlikRigidBody;
    public float MinVelocity;
    public float VelocityFactor;
    public float AdditionalForce;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Rigidbody>().velocity.y > 0)
            {
                dudlikRigidBody = other.gameObject.GetComponent<Rigidbody>();
                Vector3 downforce = new Vector3(0, -1 * VelocityFactor * dudlikRigidBody.velocity.y, 0);
                foreach (GameObject p in StaticData.Platforms)
                {
                    p.GetComponent<Rigidbody>().isKinematic = false;
                    p.GetComponent<Rigidbody>().velocity += downforce;
                }
                dudlikRigidBody.useGravity = false;
                dudlikRigidBody.velocity = new Vector3(dudlikRigidBody.velocity.x, 0, 0);
                other.gameObject.GetComponent <MovementScript>().Down = true;
                
            }
            else if (StaticData.Platforms[0].GetComponent<Rigidbody>().velocity.y > MinVelocity)
            {
                dudlikRigidBody.useGravity = true;
                dudlikRigidBody.AddForce(new Vector3(0, AdditionalForce, 0),ForceMode.Acceleration);
                foreach (GameObject p in StaticData.Platforms)
                {
                    if(p.tag == "Platform" || p.GetComponent<FragilePlatformBehaviour>().Fall != true)
                        p.GetComponent<Rigidbody>().isKinematic = true;
                }
                other.gameObject.GetComponent < MovementScript>().Down = false;
            }
            StaticData.RecordHeight += 1;
        }
    }
}
