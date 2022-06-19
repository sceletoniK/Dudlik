using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementScript : MonoBehaviour
{
    
    public float acceleration;
    public float HorForce;
    public float AdditionalResistance;
    public float LimitAdditionalResistance;

    private Rigidbody rb;
    private bool onSurface;
    public bool Down = false;
    private float sideforce;
    private float jumpforce;
    public GameObject jumpeffect;
    public GameObject jumpeffectF;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            sideforce = 1;
            if (rb.velocity.x < -1 * LimitAdditionalResistance)
                sideforce *= AdditionalResistance;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            sideforce = -1;
            if (rb.velocity.x > LimitAdditionalResistance)
                sideforce *= AdditionalResistance;
        }
        else
            sideforce = 0;
        
        if(onSurface && jumpforce == 0 && rb.velocity.y < 0.1 && !Down)
        {
            jumpforce = 1;
            gameObject.GetComponent<AudioSource>().Play();
        }
        else
            jumpforce = 0;
        rb.AddForce(new Vector3(sideforce * HorForce, jumpforce * acceleration, 0) * Time.fixedDeltaTime, ForceMode.Impulse);
        //rb.velocity = new Vector3(sideforce * HorForce, jumpforce * acceleration, 0) * Time.fixedDeltaTime;
        if (onSurface && (rb.velocity.y > 0 || Down))
            onSurface = false;  
    }

    void OnCollisionEnter(Collision other)
    {
        onSurface = true;
        if (other.gameObject.tag == "Platform")
        {
            jumpeffect.transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, 0);
            jumpeffect.GetComponent<ParticleSystem>().Play();
        }
        else if (other.gameObject.tag == "FragilePlatform")
        {
            jumpeffectF.transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, 0);
            jumpeffectF.GetComponent<ParticleSystem>().Play();
        }
    }
}
