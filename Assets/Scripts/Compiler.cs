using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Compiler : MonoBehaviour
{
    public GameObject output;

    private int baseCaseIdx;
    private int recursiveInputIdx;
    private int recursiveCallIdx;

    public static int correct;
    public static int total;

    private Text balance;
    private Text score;

    public string[] testCase;
    public int testCaseIdx;

    GameObject global;

    static int counter;

    public bool globalVerdict = true;
    public bool globalSubmit = false;

    public Text currTest;
    public Text actual;
    public Text expected;

    // Start is called before the first frame update
    void Start()
    {
        this.global = GameObject.FindGameObjectWithTag("Player");
        testCase = new string[9] { "ABA", "ABB", "A", "ABAA", "BA", "ABBABBBBA", "ABBA", "AAA", "ABABABABBA" };
        this.baseCaseIdx = 1;
        this.recursiveInputIdx = 1;
        this.recursiveCallIdx = 1;

        this.currTest = GameObject.Find("CurrTest").GetComponent<Text>();
        this.actual = GameObject.Find("Actual").GetComponent<Text>();
        this.expected = GameObject.Find("Expected").GetComponent<Text>();
    }

    public void fullReload()
    {
        SceneManager.LoadScene("StaticScene", LoadSceneMode.Single);
        total = 0;
        correct = 0;
        testCaseIdx = 5;
    }

    public void baseCaseChosen(Dropdown d)
    {
        this.baseCaseIdx = d.value + 1;
        //evaluate(testCase[testCaseIdx]);
    }

    public void recCallChosen(Dropdown d)
    {
        this.recursiveCallIdx = d.value + 1;
        //evaluate(testCase[testCaseIdx]);
    }

    public void recInputChosen(Dropdown d)
    {
        this.recursiveInputIdx = d.value + 1;
        //evaluate(testCase[testCaseIdx]);
    }

    public void next()
    {
        evaluate(testCase[testCaseIdx]);
    }
    
    void evaluate(string input)
    {

        char[] newString = "".ToCharArray();
        char[] oldString = input.ToCharArray();

        globalSubmit = false;
        bool currVerdict;

        
        switch (recursiveCallIdx)
        {
            case 2:
                currVerdict = Logic1(oldString, ref newString, ref globalSubmit);
                Debug.Log("Made it through logic case");
                break;
            case 1:
                currVerdict = Logic2(oldString, ref newString, ref globalSubmit);
                Debug.Log("Made it through logic case");
                break;
            case 3:
                currVerdict = Logic3(oldString, ref newString, ref globalSubmit);
                Debug.Log("Made it through logic case");
                break;
            default:
                currVerdict = true;
                break;
        }
        

        string newPayload = new string(newString);
        counter += 1;

        if (globalSubmit)
        {
            globalVerdict = currVerdict;
            Debug.Log(testCase[testCaseIdx] + " is a palindrome: " + globalVerdict);
            updateText();
            counter = 0;
            if (testCaseIdx < testCase.Length - 1)
            {
                Debug.Log(testCaseIdx);
                testCaseIdx += 1;
                globalSubmit = false;
            }
        } else
        {
            evaluate(newPayload);
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

    void updateText()
    {
        currTest.text = "Input: \n" + testCase[testCaseIdx];
        actual.text = "Actual Output: \n" + globalVerdict;
        expected.text = "Expected Output: \n" + getStatus(testCase[testCaseIdx]);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    bool Logic1(char[] input, ref char[] output, ref bool submit)
    {
        if (evalBaseCase(input))
        {
            submit = true;
            return true;
        }
        Debug.Log("IDX" + testCaseIdx);
        Debug.Log("How the fuck: "+new string(input));

        //Case 1 Check
        if (input[0] == input[input.Length - 1])
        {
            if (input.Length == 2)
            {
                submit = true;
                return true;
            }
            output = recursiveOutput(input);
            return true;

        }
        else
        {
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
        if (input.Length % 2 == 0)
        {
            if (input.Length > 0)
            {
                output = recursiveOutput(input);
            } else
            {
                output = input;
                submit = true;
            }
            
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
}
