using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class VehicleBehavior : MonoBehaviour
{
    //vars
    [SerializeField]
    private int input;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject uiLabel;

    [SerializeField]
    private Vector3 offset;

    private NavMeshAgent agent;

    public string id;

    public void Vehicle(string newId, int newInput)
    {
        this.id = newId;
        this.input = newInput;
        this.cam = Camera.main;
        uiLabel.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //instantiate vars
        Vehicle("yaMum", 6);
        transform.position = new Vector3(3.32f, 1.78f, 0f);

    }

    // Update is called once per frame
    void Update()
    {
        //If clicked, unhide an ui elt
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 destination = cam.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(destination);
            agent.SetDestination(destination);
        }
        else
        {
            Vector3 destination = new Vector3(-2.98f, 1.87f, 0);
            Debug.Log(destination);
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
