using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StaticData;
using UnityEngine.SceneManagement;

public class DefeatScript : MonoBehaviour
{

    public GameObject Prikol;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);

            GameObject.FindWithTag("MainCamera").GetComponents<AudioSource>()[0].Pause();
            GameObject.FindWithTag("MainCamera").GetComponents<AudioSource>()[1].PlayDelayed(1);

            foreach(GameObject p in GameObject.FindGameObjectsWithTag("Neco"))
                p.GetComponent<NecoScript>().active = false;

            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(4);

        if (!PlayerPrefs.HasKey("PlayerRecord") || PlayerPrefs.GetFloat("PlayerRecord") < StaticData.RecordHeight)
        {
            PlayerPrefs.SetFloat("PlayerRecord", StaticData.RecordHeight);
            GameObject.FindWithTag("MainCamera").GetComponents<AudioSource>()[2].Play();

            Prikol.SetActive(true);

            yield return new WaitForSeconds(7);
        }

        SceneManager.LoadScene("Menu");
        Prikol.SetActive(false);

    }
}
