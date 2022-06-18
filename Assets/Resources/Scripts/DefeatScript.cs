using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticData;
using UnityEngine.SceneManagement;

public class DefeatScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!PlayerPrefs.HasKey("PlayerRecord") || PlayerPrefs.GetFloat("PlayerRecord") < StaticData.RecordHeight)
                PlayerPrefs.SetFloat("PlayerRecord", StaticData.RecordHeight);
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }
}
