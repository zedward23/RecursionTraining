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

    // Update is called once per frame
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
            collision.gameObject.GetComponent<VehicleBehavior>().Kill();

            GameObject newCreation = Instantiate(output);
            Debug.Log("created");
            newCreation.transform.position = new Vector3(3.14f, 1.88f, 0f);
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


    void Logic1(List<string> info)
    {
        //Logic here - example for correct ForLoop implementation
        int currNum = Int32.Parse(info[0]);
        //Global.money -= $$
        if (currNum == 0)
        {
            BaseCase1(info);
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
    List<string> BaseCase1(List<string> info)
    {
        Debug.Log("Yerp this is indeed the basecase");
        List<string> ret = new List<string>();
        ret.Add("");
        return ret;
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
