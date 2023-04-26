using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class FactoryBehavior : MonoBehaviour
{
    public GameObject output;

    private int baseCaseIdx;
    private int recursiveInputIdx;
    private int recursiveCallIdx;
    
    

    GameObject global;

    // Start is called before the first frame update
    void Start()
    {
        this.global = GameObject.FindGameObjectWithTag("Player");
        



    }

    // Update is called once per frame
    void Update()
    {
        this.baseCaseIdx = global.GetComponent<GlobalBehavior>().baseCaseIdx;
        this.recursiveInputIdx = global.GetComponent<GlobalBehavior>().recursiveInputIdx;
        this.recursiveCallIdx = global.GetComponent<GlobalBehavior>().recursiveCallIdx;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<VehicleBehavior>() != null)
        {
            string haha = collision.gameObject.GetComponent<VehicleBehavior>().id;
            Debug.Log("id:" + haha);

            string payload = collision.gameObject.GetComponent<VehicleBehavior>().getPayload();

            Debug.Log("Payload: " + payload);

            char[] newString = "".ToCharArray();
            char[] oldString = payload.ToCharArray();

            GlobalBehavior.cash -= (int)(GlobalBehavior.cash / (oldString.Length * 1.8));
            if (GlobalBehavior.cash < 0)
            {
                GlobalBehavior.testCaseIdx = GameObject.FindGameObjectWithTag("Player").GetComponent<GlobalBehavior>().testCase.Length;
            }

            bool submit = false;

            bool currVerdict;

            switch (recursiveCallIdx)
            {
                case 2:
                    currVerdict = Logic1(oldString, ref newString, ref submit);
                    Debug.Log("Made it through logic case");
                    break;
                case 1:
                    currVerdict = Logic2(oldString, ref newString, ref submit);
                    Debug.Log("Made it through logic case");
                    break;
                case 3:
                    currVerdict = Logic3(oldString, ref newString, ref submit);
                    Debug.Log("Made it through logic case");
                    break;
                default:
                    currVerdict = true;
                    break;
            }

            if (currVerdict)
            {
                GameObject.Find("RecursiveCall").GetComponent<Image>().color = new Color(0f, 255f, 0f);
            } else
            {
                GameObject.Find("RecursiveCall").GetComponent<Image>().color = new Color(255f, 0f, 0f);
            }
            

            string newPayload = new string(newString);
            Debug.Log(newString.Length);

            if (newString.Length == 0)
            {
                submit = true;
            }

            collision.gameObject.GetComponent<VehicleBehavior>().Kill();

            output.transform.position = new Vector3(3.52f, 1.74f, 0f);
            GameObject newCreation = Instantiate(output);
            
            newCreation.GetComponent<VehicleBehavior>().setReviewStatus(submit);
            
            if (submit)
            {
                newCreation.GetComponent<VehicleBehavior>().setPayload(VehicleBehavior.originalPayload);
            } else
            {
                newCreation.GetComponent<VehicleBehavior>().setPayload(newPayload);
            }

            newCreation.GetComponent<VehicleBehavior>().setVerdict(currVerdict);



            Debug.Log("old string: " + payload);
            Debug.Log("new string: " + new string(newString));
        }
        /**/
    }

    bool evalBaseCase(char[] input)
    {
        switch (this.baseCaseIdx)
        {
            case 1:
                return input.Length == 1;
            case 2:
                return input.Length == 2;
            case 3:
                print("I'm here for some reason");
                return input[0] == input[input.Length - 1];
            default:
                return false;
        }
    }

    char[] recursiveOutput(char[] input)
    {
        if (input.Length <= 1)
        {
            return input;
        }
        switch (this.recursiveInputIdx)
        {
            case 3:
                return new List<char>(input).GetRange(1, input.Length - 2).ToArray();
            case 1:
                return new List<char>(input).GetRange(1, input.Length - 2).ToArray();
            case 2:
                return new List<char>(input).GetRange(0, input.Length - 1).ToArray();
            default:
                return input;
        }
        
    }

    bool Logic1(char[] input, ref char[] output, ref bool submit) {
        if (evalBaseCase(input))
        {
            submit = true;
            return true;
        }

        Debug.Log(new string(input));

        //Case 1 Check
        if (input[0] == input[input.Length - 1])
        {
            output = recursiveOutput(input);
            return true;
            
        } else {
            submit = true;
            return false;
        }
    }
    bool Logic2(char[] input, ref char[] output, ref bool submit)
    {
        if (evalBaseCase(input))
        {
            submit = true;
            return true;
        }

        //Case 2 Check
        if (input.Length% 2 == 0)
        {
            output = recursiveOutput(input);
            return true;

        }
        else
        {
            submit = true;
            return false;
        }
    }

    bool Logic3(char[] input, ref char[] output, ref bool submit)
    {
        if (evalBaseCase(input))
        {
            submit = true;
            return true;
        }

        if (input.Length < 1)
        {
            output = new char['@'];
            submit = false;
            return false;
        }

        //Case 3 Check
        if (input[0] == input[1])
        {
            output = recursiveOutput(input);
            return true;
        }
        else
        {
            submit = true;
            return false;
        }

    }
    void Logic4()
    {

    }
 
}
