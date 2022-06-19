using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticMenuData : MonoBehaviour
{


    void Start()
    {
        if (!PlayerPrefs.HasKey("Audio"))
            PlayerPrefs.SetInt("Audio", 1);
        if(PlayerPrefs.GetInt("Audio") == 0)
            gameObject.GetComponentInChildren<Text>().text = "�������� ���� � ����������";
    }

    public void SwitchAudio()
    {
        if(PlayerPrefs.GetInt("Audio") == 1)
        {
            PlayerPrefs.SetInt("Audio", 0);
            gameObject.GetComponentInChildren<Text>().text = "�������� ���� � ����������";
        }
        else
        {
            PlayerPrefs.SetInt("Audio", 1);
            gameObject.GetComponentInChildren<Text>().text = "��������� ���� � ����������";
        }
    }
}
