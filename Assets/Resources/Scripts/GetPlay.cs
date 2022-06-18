using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlay : MonoBehaviour
{
    void Update()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
    }
}
