using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GlobalBehavior : MonoBehaviour
{

    public GameObject output;

    public int baseCaseIdx;
    
    public int recursiveInputIdx;
    
    public int recursiveCallIdx;

    private Dropdown[] dropdowns;

    private int id;

    public static bool playing = false;

    private static int globalCount = 0;


    public string OriginalPayload;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        VehicleBehavior.originalPayload = OriginalPayload;
        id = globalCount;
        globalCount += 1;
        if (this.id > 0)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        this.baseCaseIdx = 1;
        this.recursiveInputIdx = 1;
        this.recursiveCallIdx = 1;

        GameObject newCreation = Instantiate(output);
        GameObject.FindGameObjectWithTag("Vehicle").GetComponent<NavMeshAgent>().enabled = false;
        newCreation.transform.position = new Vector3(-9.8f, 1.6f, 0f);
        newCreation.GetComponent<VehicleBehavior>().setReviewStatus(true);
        newCreation.GetComponent<VehicleBehavior>().setPayload(VehicleBehavior.originalPayload);
        newCreation.GetComponent<VehicleBehavior>().setVerdict(true);

        playing = false;
    }

    public void baseCaseChosen(Dropdown d)
    {
        Debug.Log("Value Chosen " + d.value);
        this.baseCaseIdx = d.value + 1;
        SceneManager.LoadScene("RecursionScene", LoadSceneMode.Single);
    }

    public void recCallChosen(Dropdown d)
    {
        Debug.Log("Value Chosen " + d.value);
        this.recursiveCallIdx = d.value + 1;
        SceneManager.LoadScene("RecursionScene", LoadSceneMode.Single);
    }

    public void recInputChosen(Dropdown d)
    {
        Debug.Log("Value Chosen " + d.value);
        this.recursiveInputIdx = d.value + 1;
        SceneManager.LoadScene("RecursionScene", LoadSceneMode.Single);
    }

    public void togglePlay()
    {
        GlobalBehavior.playing = !GlobalBehavior.playing;
    }

    public void reload(Dropdown d)
    {
        this.recursiveInputIdx = d.value + 1;
        SceneManager.LoadScene("RecursionScene", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
