using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeWhenActive : MonoBehaviour
{
    public Transform cameraTransform;
    public Vector3 startingPosition;
        float timePassed = 0f;

    void Start()
    {
        startingPosition = cameraTransform.transform.position;
        // StartCoroutine(logEverySecond());
        //  InvokeRepeating("StartShake", 1.0f, 4f);
    
    }
    void Update()
    {
        timePassed += Time.deltaTime;
        if(timePassed > 0.6f)
        {
            //do something
            Shake();
            timePassed = 0f;
        } 
        // Shake();
    }
    public void Shake()
    {
        CameraController.instance.StartShake(.2f, .1f);
    }
}
