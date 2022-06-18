using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PutNewRecord : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = gameObject.GetComponent<Text>();
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerRecord"))
            text.text = PlayerPrefs.GetFloat("PlayerRecord").ToString();
    }

}
