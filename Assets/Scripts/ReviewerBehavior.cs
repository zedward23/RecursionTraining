using System.Collections;
using System.Collections.Generic;
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

            Debug.Log("Verdict:" + verdict);

        }
    }
}
