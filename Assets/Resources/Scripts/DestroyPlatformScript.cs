using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticData;

public class DestroyPlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "FragilePlatform")
        {
            Destroy(other.gameObject);
            StaticData.CreatePlatforms();
        }
    }
}