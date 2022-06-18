using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSessionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartSession()
    {
        SceneManager.LoadScene("GameSession");
    }
}
