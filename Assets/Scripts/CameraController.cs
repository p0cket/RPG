using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Tilemap theMap;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;

    public int musicToPlay;
    private bool musicStarted;
    public float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;
    public float rotationMultiplier = 15f;

    public static CameraController instance;

    void Start()
    {
        instance = this;

        target = PlayerController.instance.transform;
        // target = FindObjectOfType<PlayerController>().transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);

        PlayerController.instance.SetBounds(theMap.localBounds.min, theMap.localBounds.max);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            // StartShake(shakeTimeRemaining, shakePower);
            StartShake(0.25f, 0.05f);

        }
    }

    // LateUpdate is called once per frame after Update
    void LateUpdate()
    {
        if(shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;
            float xAmount = Random.Range(-1f, 1f) * shakePower;
            float yAmount = Random.Range(-1f, 1f) * shakePower;

            transform.position += new Vector3(xAmount, yAmount, 0f);

            shakePower = Mathf.MoveTowards(shakePower, 0f, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0f, shakeFadeTime * rotationMultiplier * Time.deltaTime); 
        } else {
            transform.rotation = Quaternion.Euler(0f, 0f, shakeRotation * Random.Range(-1f, 1f));

            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

            // Keep the camera inside the bounds
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

            if(!musicStarted)
            {
                musicStarted = true;
                AudioManager.instance.PlayBGM(musicToPlay);
            }
        }
    }

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power/length;

        shakeRotation = power * rotationMultiplier;
    }
}

    // public float shakeTimeRemaining, shakePower;

    // // Update is called once per frame
    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.V))
    //     {
    //         Debug.Log("V");
    //         StartShake(.5f, 1f);
    //     }
    // }

    // private void LateUpdate()
    // {
    //     if(shakeTimeRemaining > 0)
    //     {
    //         Debug.Log("shaking");
    //         shakeTimeRemaining -= Time.deltaTime;
    //         float xAmount = Random.Range(-1f, 1f) * shakePower;
    //         float yAmount = Random.Range(-1f, 1f) * shakePower;

    //         transform.position += new Vector3(xAmount, yAmount, 0f);
    //     }
    // }

    // public void StartShake(float length, float power)
    // {
    //     Debug.Log("StartShake");
    //     shakeTimeRemaining = length;
    //     shakePower = power;
    // }