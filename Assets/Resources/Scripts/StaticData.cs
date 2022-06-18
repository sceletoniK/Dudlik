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
    static public float RecordHeight;

    private static float hight;
    // Start is called before the first frame update
    void Awake()
    {
        verticalRange = VerticalRange;
        Platform = (GameObject)Resources.Load("Prefabs/Platform/Platform", typeof(GameObject));

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

        GameObject.Find("NewRecordPrikol").GetComponent<CanvasGroup>().alpha = 0;
    }

    public static void CreatePlatforms()
    {
        hight = Platforms.Max(x => x.GetComponent<Transform>().position.y);

        while (hight <= 30)
        {
            Platforms.Add(Instantiate(Platform, new Vector3(Random.Range(-5.3f, 5.3f), Random.Range(hight, hight + verticalRange), 0), Quaternion.identity));

            hight = Platforms.Max(x => x.GetComponent<Transform>().position.y);
        }
    }

}
