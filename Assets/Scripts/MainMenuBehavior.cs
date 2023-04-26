using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    private static bool unlockFreePlay = false;

    static GameObject FreePlay;
    
    // Start is called before the first frame update
    void Start()
    {
        FreePlay = GameObject.Find("FreePlay");
        FreePlay.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void checkPassword(Text input)
    {
        unlockFreePlay = (input.text == "WH299");
        if (unlockFreePlay)
        {
            FreePlay.SetActive(true);
        }
    }

    public void loadRandomScene()
    {
        if (Random.Range(-10.0f, 10.0f) > 0)
        {
            SceneManager.LoadScene("StaticScene", LoadSceneMode.Single);
        } else
        {
            SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
        }
    }

    public void loadStaticScene()
    {
        SceneManager.LoadScene("StaticScene", LoadSceneMode.Single);
    }

    public void loadDynamicScene()
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
    }
}
