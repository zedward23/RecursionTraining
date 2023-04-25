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
    private Vector3 offset;

    private NavMeshAgent agent;

    public string id;

    public void Vehicle(string newId, string newInput)
    {
        this.id = newId;
        this.input = newInput;
        this.cam = Camera.main;
        uiLabel.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
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

        //transform.position = new Vector3(3.32f, 1.78f, 0f);
        

    }

    // Update is called once per frame
    void Update()
    {
        
        //If clicked, unhide an ui elt
        if (submitForReview)
        {
            Vector3 currPos = gameObject.transform.position;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            gameObject.transform.position = new Vector3(currPos.x + .01f, currPos.y, currPos.z);
        }
        else
        {
            gameObject.GetComponent<NavMeshAgent>().enabled = true;
            Vector3 destination = new Vector3(-2.98f, 1.87f, 0);
            agent.SetDestination(destination);
        }

    }

    private void OnMouseOver()
    {
        uiLabel.SetActive(true);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        Debug.Log("Input is: " + input);
        Debug.Log("Screen Space Coords are" + screenPos);

        uiLabel.transform.position = screenPos + offset;
        uiLabel.GetComponent<Text>().text = "Payload: " + this.input.ToString();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnMouseExit()
    {
        uiLabel.SetActive(false);
    }

    private void OnMouseDown()
    {
        
        
    }
}
