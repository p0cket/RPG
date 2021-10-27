using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodTest : MonoBehaviour
{
    // Basically, Fungus has a Command called "Call Method"
    // You add an object, and then what method to call from that obj
    // So here we have a Method below. Attach the script to an Empty Obj
    // The Method Name will be 'LogAnything', and it'll just work
    public void LogAnything()
    {
        //All your code will go here
        Debug.Log("This happens mid script");
    }
}
