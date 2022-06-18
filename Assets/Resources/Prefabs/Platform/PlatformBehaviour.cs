using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticData;

public class PlatformBehaviour : MonoBehaviour
{
    private BoxCollider Box;
    private Rigidbody Dudlik;

    void Awake()
    {
        Box = gameObject.GetComponent<BoxCollider>();
        Dudlik = StaticData.MainDudlik.GetComponent<Rigidbody>();
    }

    void OnDestroy()
    {
        StaticData.Platforms.Remove(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && (Dudlik.velocity.y <= 0 || other.gameObject.GetComponent<MovementScript>().Down))
            Box.enabled = true;
    }
        
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Box.enabled = false;
    }
}