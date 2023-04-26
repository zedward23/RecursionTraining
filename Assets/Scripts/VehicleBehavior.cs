using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class VehicleBehavior : MonoBehaviour
{
    //vars
    [SerializeField]
    private string input;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private bool submitForReview;
    private bool verdict;

    [SerializeField]
    private GameObject uiLabel;

    [SerializeField]
    private GameObject image;

    [SerializeField]
    private Vector3 offset;

    public NavMeshAgent agent;

    public string id;

    public static string originalPayload;

    

    public void Vehicle(string newId, string newInput)
    {
        this.id = newId;
        this.input = newInput;
        this.cam = Camera.main;
        uiLabel.SetActive(false);
        image.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public string getPayload()
    {
        return input;
    }
    public bool getVerdict()
    {
        return this.verdict;
    }
    public void setVerdict(bool verdict)
    {
        this.verdict = verdict;
    }

    public bool getReviewStatus()
    {
        return this.submitForReview;
    }
    public void setReviewStatus(bool submit)
    {
        this.submitForReview = submit;
    }

    public void setPayload(string newPayload)
    {
        this.input = newPayload;
    }

    // Start is called before the first frame update
    void Start()
    {
        //instantiate vars
        Vehicle(id, input);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GlobalBehavior.playing)
        {
            
            if (submitForReview)
            {
                Vector3 currPos = gameObject.transform.position;
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                gameObject.transform.position = new Vector3(currPos.x + .05f, currPos.y, currPos.z);
                input = VehicleBehavior.originalPayload;

            }
            else
            {
                gameObject.GetComponent<NavMeshAgent>().enabled = true;
                Vector3 destination = new Vector3(-2.98f, 1.87f, 0);
                agent.SetDestination(destination);
            }
        } else
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
        }

    }

    private void OnMouseOver()
    {
        uiLabel.SetActive(true);
        image.SetActive(true);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Debug.Log("Input is: " + input);
        Debug.Log("Screen Space Coords are" + screenPos);

        image.transform.position = screenPos + offset + new Vector3(0f, 70f, 0f);
        //uiLabel.transform.position = screenPos + offset;
        uiLabel.GetComponent<Text>().text = "Payload: " + this.input.ToString();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnMouseExit()
    {
        uiLabel.SetActive(false);
        image.SetActive(false);
    }

    private void OnMouseDown()
    {
        
        
    }
}
