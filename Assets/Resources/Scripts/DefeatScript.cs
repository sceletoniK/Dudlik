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
            other.gameObject.SetActive(false);

            GameObject.FindWithTag("MainCamera").GetComponents<AudioSource>()[0].Pause();
            GameObject.FindWithTag("MainCamera").GetComponents<AudioSource>()[1].PlayDelayed(1);

            if (!PlayerPrefs.HasKey("PlayerRecord") || PlayerPrefs.GetFloat("PlayerRecord") < StaticData.RecordHeight)
            {
                PlayerPrefs.SetFloat("PlayerRecord", StaticData.RecordHeight);
                GameObject.FindWithTag("MainCamera").GetComponents<AudioSource>()[2].PlayDelayed(1);

                StartCoroutine(Death(9));
            }
            else
                StartCoroutine(Death(2));
        }
    }

    IEnumerator Death(int delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Menu");
    }
}
