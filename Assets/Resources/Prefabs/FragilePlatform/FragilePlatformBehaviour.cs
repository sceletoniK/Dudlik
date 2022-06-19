using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticData;

public class FragilePlatformBehaviour : MonoBehaviour
{
    private BoxCollider Box;
    private Rigidbody Dudlik;
    public bool Fall = false;

    void Awake()
    {
        Box = gameObject.GetComponent<BoxCollider>();
        Dudlik = StaticData.MainDudlik.GetComponent<Rigidbody>();
    }

    void OnDestroy()
    {
        StaticData.Platforms.Remove(gameObject);

        //Код на эффект
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && Dudlik.velocity.y < 0)
            Box.enabled = true;
    }
        
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !Fall)
            Box.enabled = false;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}