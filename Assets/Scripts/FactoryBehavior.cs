using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FactoryBehavior : MonoBehaviour
{
    public GameObject output;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frameF
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Look ma i'm in a trigger");
        if (collision.gameObject.GetComponent<VehicleBehavior>() != null)
        {
            string haha = collision.gameObject.GetComponent<VehicleBehavior>().id;
            Debug.Log("id:" + haha);

            string payload = collision.gameObject.GetComponent<VehicleBehavior>().getPayload();

            Debug.Log("Payload: " + payload);

            char[] newString = "".ToCharArray();

            bool submit = false;

            bool currVerdict = Logic1(payload.ToCharArray(), ref newString, ref submit);

            string newPayload = new string(newString);
            Debug.Log(newString.Length);

            if (newString.Length == 0)
            {
                submit = true;
            }

            print("submit?" + submit);

            collision.gameObject.GetComponent<VehicleBehavior>().Kill();

            output.transform.position = new Vector3(3.52f, 1.74f, 0f);
            GameObject newCreation = Instantiate(output);
            newCreation.GetComponent<VehicleBehavior>().setPayload(newPayload);
            newCreation.GetComponent<VehicleBehavior>().setReviewStatus(submit);
            newCreation.GetComponent<VehicleBehavior>().setVerdict(currVerdict);



            Debug.Log("old string: " + payload);
            Debug.Log("new string: " + new string(newString));

            

            
            //newCreation.GetComponent<VehicleBehavior>().setPayload(newString.ToString());

            Debug.Log("created");
            
        }
        /**/
    }
    //On Collision Enter(Vehicle v){
    //auto info = v.getInfo
    //v.destory()
    //switch(global.useChoice):
    //case1:
    // Logic1(info)
    //case2:....


    bool Logic1(char[] input, ref char[] output, ref bool submit) {
    
        //Logic here - example for correct ForLoop implementation
        
        if (!BaseCase1(input))
        {
            if (input[0] == input[input.Length - 1])
            {
                output = new List<char>(input).GetRange(1, input.Length - 2).ToArray();
                return true;
                
            } else {
                submit = true;
                return false;
            }
        } else
        {
            submit = true;
            return true;
        }


        //Spawn new Vehicle
        //Instantiate new Vehicle(currNum-1)
    }
    void Logic2()
    {

    }

    void Logic3()
    {

    }
    void Logic4()
    {

    }
    bool BaseCase1(char[] input)
    {
        Debug.Log("Base case check:" + new string(input));
        if (input.Length == 1)
        {
            return true;
        } else
        {
            return false;
        }
        
    }
    void BaseCase2()
    {

    }
    void BaseCase3()
    {

    }
    void BaseCase4()
    {

    }
}
