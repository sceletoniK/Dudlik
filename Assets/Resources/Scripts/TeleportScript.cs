using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeleportScript : MonoBehaviour
{
    public float VelocityFactor;
    public float HelpVertical;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Transform l = other.gameObject.GetComponent<Transform>();
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            other.gameObject.GetComponent<Transform>().position = new Vector3(-1 * Math.Sign(l.position.x) * 8.25f,l.position.y + HelpVertical,0);
            rb.velocity = new Vector3(VelocityFactor * rb.velocity.x,rb.velocity.y,0);
        }
    }

}
