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

    public int id;

    public static bool playing = false;

    private static int globalCount;

    public static int testCaseIdx;

    public static int cash = 10000;

    public static int correct;
    public static int total;

    private Text balance;
    private Text score;

    public string OriginalPayload;

    public string[] testCase;


    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().buildIndex) {
            case 2:
                GameObject.Find("CanvasDynamic").SetActive(true);
                GameObject.Find("CanvasStatic").SetActive(false);
                break;
            case 3:
                GameObject.Find("CanvasDynamic").SetActive(false);
                GameObject.Find("CanvasStatic").SetActive(true);
                break;
            default:
                GameObject.Find("CanvasDynamic").SetActive(false);
                GameObject.Find("CanvasStatic").SetActive(false);
                break;
                
        }

        balance = GameObject.Find("Balance").GetComponent<Text>();
        score = GameObject.Find("Score").GetComponent<Text>();
        testCase = new string[9] { "ABA", "ABB", "A", "ABAA", "BA", "ABBABBBBA", "ABBA", "AAA", "ABABABABBA" };
        
        OriginalPayload = testCase[testCaseIdx];

        VehicleBehavior.originalPayload = OriginalPayload;
        id = globalCount;
        globalCount += 1;
        

        if (GameObject.FindGameObjectWithTag("Player") != null && (
            GameObject.FindGameObjectWithTag("Player").GetComponent<GlobalBehavior>().id < this.id || SceneManager.GetActiveScene().buildIndex != 2))
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

        GameObject.Find("RecursiveCall").GetComponent<Image>().color = new Color(255f, 255f, 255f);
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

    public void reload()
    {
        SceneManager.LoadScene("RecursionScene", LoadSceneMode.Single);   
    }

    public void fullReload()
    {
        SceneManager.LoadScene("RecursionScene", LoadSceneMode.Single);
        total = 0;
        correct = 0;
        testCaseIdx = 0;
        cash = 10000;
    }


    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            Destroy(gameObject);
        }
        if (cash < 0)
        {
            balance.text = "BANKRUPT";
            
        } else
        {
            balance.text = "Cash Balance: $" + cash;
        }

        score.text = correct + "/" + total + " orders processed correctly";
    }
}