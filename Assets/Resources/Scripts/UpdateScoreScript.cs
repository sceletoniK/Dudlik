using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static StaticData;

public class UpdateScoreScript : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = gameObject.GetComponent<Text>();
    }

    void FixedUpdate()
    {
        text.text = StaticData.RecordHeight.ToString();
    }

}
