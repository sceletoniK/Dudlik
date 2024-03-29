using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    public float VerticalRange;
    private static float verticalRange;
    public static GameObject MainDudlik;
    public static List<GameObject> Platforms;
    public static GameObject Platform;
    public static GameObject FragilePlatform;
    static public float RecordHeight;

    public GameObject[] Necos = new GameObject[2];
    public AudioSource Music;

    private static float hight;
    
    void Awake()
    {
        verticalRange = VerticalRange;
        Platform = (GameObject)Resources.Load("Prefabs/Platform/Platform", typeof(GameObject));
        FragilePlatform = (GameObject)Resources.Load("Prefabs/FragilePlatform/FragilePlatform", typeof(GameObject));

        foreach (GameObject p in GameObject.FindGameObjectsWithTag("Triggers"))
        {
            p.GetComponent<MeshRenderer>().enabled = false;
        }

        Platforms = new List<GameObject>();
        MainDudlik = GameObject.Find("MainDudlik");

        Platforms.Add(Instantiate(Platform, new Vector3(0, 0, 0), Quaternion.identity));

        CreatePlatforms();
        
    }

    private void Start()
    {
        RecordHeight = 0;
        MainDudlik.SetActive(true);

        GameObject.FindWithTag("MainCamera").GetComponents<AudioSource>()[0].Play();

        if(PlayerPrefs.GetInt("Audio") == 0)
        {
            foreach (GameObject p in Necos)
                p.SetActive(false);
            Music.volume = 0;
        }
    }

    public static void CreatePlatforms()
    {
        hight = Platforms.Max(x => x.GetComponent<Transform>().position.y);

        while (hight <= 30)
        {
            Platforms.Add(Instantiate(Platform, new Vector3(Random.Range(-5.3f, 5.3f), Random.Range(hight, hight + verticalRange), 0), Quaternion.identity));

            if (Random.Range(0f, 1f) >= 0.75)
            {
                Platforms.Add(Instantiate(Platform, new Vector3(Random.Range(-5.3f, 5.3f), Random.Range(hight, hight + verticalRange + 0.2f), 0), Quaternion.identity));
            }

            hight = Platforms.Max(x => x.tag == "Platform" ? x.GetComponent<Transform>().position.y : -1 );

            if(Random.Range(0f,1f) >= 0.85)
            {
                Platforms.Add(Instantiate(FragilePlatform, new Vector3(Random.Range(-5.2f, 5.2f), Random.Range(hight, hight + verticalRange + 0.25f), 0), Quaternion.identity));
            }
        }
    }

}
