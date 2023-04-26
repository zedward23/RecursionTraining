using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ReviewerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<VehicleBehavior>() != null)
        {
            bool verdict = collision.gameObject.GetComponent<VehicleBehavior>().getVerdict();
            collision.gameObject.GetComponent<VehicleBehavior>().Kill();

            Debug.Log("Verdict: " + verdict);
            Debug.Log("Ground Truth: " + getStatus(VehicleBehavior.originalPayload));

            Debug.Log("Are you getting paid? " + (verdict == getStatus(VehicleBehavior.originalPayload)));
        }
    }

    public static bool getStatus(string myString)
    {
        string first = myString.Substring(0, myString.Length / 2);
        char[] arr = myString.ToCharArray();

        Array.Reverse(arr);

        string temp = new string(arr);
        string second = temp.Substring(0, temp.Length / 2);

        return first.Equals(second);
    }

}
