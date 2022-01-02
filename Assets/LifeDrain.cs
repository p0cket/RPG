using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDrain : MonoBehaviour
{
    public float amtToDrain = 5f;
    public float curDrain = 0f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(curDrain >= amtToDrain){
                Debug.Log("Drained Fully, Do next thing");
            } else {
                curDrain += 0.3f * Time.deltaTime;
                Debug.Log("Drainging: "+curDrain+" out of "+amtToDrain);
            }
        }
    }
}
