using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TeleportScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Transform l = other.gameObject.GetComponent<Transform>();
            l.position = new Vector3(-1 * Math.Sign(l.position.x) * 8.25f,l.position.y,0);
        }
    }

}
