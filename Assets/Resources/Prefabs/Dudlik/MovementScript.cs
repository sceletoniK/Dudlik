using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementScript : MonoBehaviour
{
    
    public float acceleration;
    public float HorForce;

    private Rigidbody rb;
    private Transform trans;
    private bool onSurface;
    public bool Down = false;
    private float sideforce;
    private float jumpforce;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        trans = gameObject.GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))//&& rb.velocity.x < MaxSpeed)
            sideforce = 1;
        else if (Input.GetKey(KeyCode.A)) //&& Math.Abs(rb.velocity.x) < MaxSpeed)
            sideforce = -1;
        else
            sideforce = 0;

        if (onSurface)
            jumpforce = 1;
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
    }
}
