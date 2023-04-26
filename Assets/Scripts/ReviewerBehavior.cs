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
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x + 10000, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);

            Debug.Log("Verdict: " + verdict);
            Debug.Log("Ground Truth: " + getStatus(VehicleBehavior.originalPayload));

            GlobalBehavior global = GameObject.FindGameObjectWithTag("Player").GetComponent<GlobalBehavior>();

            if ((verdict == getStatus(VehicleBehavior.originalPayload)))
            {
                GlobalBehavior.cash += 12000;
                GlobalBehavior.correct += 1;
            }
            else
            {
                GlobalBehavior.cash -= 8000;
                if (GlobalBehavior.cash < 0)
                {
                    GlobalBehavior.testCaseIdx = global.testCase.Length;
                }
            }

            GlobalBehavior.total += 1;

            if (GlobalBehavior.testCaseIdx < global.testCase.Length-1)
            {
                GlobalBehavior.testCaseIdx += 1;
                GameObject.FindGameObjectWithTag("Player").GetComponent<GlobalBehavior>().reload();
            }
            

            

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
