using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NecoScript : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer SpriteRender;
    public bool active = true;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRender = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
            SpriteRender.sprite = sprites[(int)(Time.time * 10) % sprites.Length];
    }
}
